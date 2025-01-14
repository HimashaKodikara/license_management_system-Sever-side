﻿using license_management_system_Sever_side.Data;
using license_management_system_Sever_side.Models.DTOs;
using license_management_system_Sever_side.Models.Entities;
using license_management_system_Sever_side.Services.EndClientSerives;
using license_management_system_Sever_side.Services.RequestKeySerives;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace license_management_system_Sever_side.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequestKeyController : ControllerBase
    {
        private readonly IRequestKeySerives _request_key;
        private readonly IEndClientService _endClientService;
        private readonly DataContext _context;

        public RequestKeyController(IRequestKeySerives requestkeyserives, IEndClientService endClientService, DataContext context)
        {
            _request_key = requestkeyserives;
            _endClientService = endClientService;
            _context = context;
        }

        //add request key
        [HttpPost("addRequestKey")]
        public async Task<IActionResult> AddRequestKey(RequestKeyDto requestKey)
        {
            // Set the comment properties to null if they are empty strings
            if (string.IsNullOrWhiteSpace(requestKey.CommentFinaceMgt))
            {
                requestKey.CommentFinaceMgt = null;
            }

            if (string.IsNullOrWhiteSpace(requestKey.CommentPartnerMgt))
            {
                requestKey.CommentPartnerMgt = null;
            }
            requestKey.isFinanceApproval = false;
            requestKey.isPartnerApproval = false;

            await _request_key.AddRequestKey(requestKey);

            return Ok();
        }


        //get all request keys
        [HttpGet("getAllRequestKeys")]
        public async Task<IActionResult> GetAllRequestKeys()
        {
            var requestKeys = await _request_key.GetAllrequestkeys();
            return Ok(requestKeys);
        }
        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RequestKey>>> GetAllRequestKeysWith()
        {
            // Include EndClient details in the query
            var requestKeys = await _context.RequestKeys.Include(r => r.EndClient).ToListAsync();

            return Ok(requestKeys);
        }
        
        // PATCH: api/PAfinanceTCH/5/SetFinanceTrue
        [HttpPatch("{id}/SetFinanceTrue")]
        public async Task<IActionResult> SetFinanceTrue(int id)
        {
            var client = await _context.RequestKeys.FindAsync(id);
            if (client == null)
            {
                return NotFound();
            }

            client.isFinanceApproval = true;

            _context.Entry(client).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClientExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // PATCH: api/PAfinanceTCH/5/SetPartnerTrue
        [HttpPatch("{id}/SetPartnerTrue")]
        public async Task<IActionResult> SetPartnerTrue(int id)
        {
            var client = await _context.RequestKeys.FindAsync(id);
            if (client == null)
            {
                return NotFound();
            }

            client.isPartnerApproval = true;

            _context.Entry(client).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClientExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        private bool ClientExists(int id)
        {
            return _context.RequestKeys.Any(e => e.RequestID == id);
        }

        // PATCH: api/RequestKey/{request_id}/Reject
        [HttpPatch("{request_id}/RejectFianceMgt")]
        public async Task<IActionResult> RejectRequest(int request_id, [FromBody] string rejectionReason)
        {
            var requestKey = await _context.RequestKeys.FindAsync(request_id);

            if (requestKey == null)
            {
                return NotFound();
            }

            // Update the CommentFinaceMgt column with the rejection reason
            requestKey.CommentFinaceMgt = rejectionReason;

            // Update the Partner Manager status to Rejected
            requestKey.isFinanceApproval = false;

            _context.Entry(requestKey).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RequestKeyExists(request_id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // PATCH: api/RequestKey/{request_id}/Reject
        [HttpPatch("{request_id}/RejectFiancePart")]
        public async Task<IActionResult> RejectRequestPart(int request_id, [FromBody] string rejectionReason)
        {
            var requestKey = await _context.RequestKeys.FindAsync(request_id);

            if (requestKey == null)
            {
                return NotFound();
            }

            // Update the CommentFinaceMgt column with the rejection reason
            requestKey.CommentPartnerMgt = rejectionReason;

            // Update the Partner Manager status to Rejected
            requestKey.isPartnerApproval = false;

            _context.Entry(requestKey).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RequestKeyExists(request_id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        private bool RequestKeyExists(int id)
        {
            return _context.RequestKeys.Any(e => e.RequestID == id);
        }

    }
}
