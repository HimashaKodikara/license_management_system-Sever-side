﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using license_management_system_Sever_side.Data;
using license_management_system_Sever_side.Migrations;
using license_management_system_Sever_side.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace license_management_system_Sever_side.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientSTController : ControllerBase
    {
        private readonly AplicationDbContext _context;

        public ClientSTController(AplicationDbContext context)
        {
            _context = context;
        }

        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClientST>>> GetClientST()
        {
            if (_context.ClientSTs == null)
            {
                return NotFound();
            }
            return await _context.ClientSTs.ToListAsync();
        }

        // GET: api/ClientPanal/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ClientST>> GetClientSTById(int id)
        {
            var client = await _context.ClientSTs.FindAsync(id);

            if (client == null)
            {
                return NotFound();
            }

            return Ok(client);
        }

        // POST: api/ClientPanal
        [HttpPost]
        public async Task<ActionResult<ClientST>> CreateClientST(ClientST client)
        {
            _context.ClientSTs.Add(client);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetClientSTById), new { id = client.CID }, client);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> PutClientST(int id, ClientST clientST)
        {
            if (id != clientST.CID)
            {
                return BadRequest();
            }

            // Retrieve the existing client from the database
            var existingClient = await _context.ClientSTs.FindAsync(id);

            if (existingClient == null)
            {
                return NotFound();
            }

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return Ok();
        }
        // DELETE: api/ClientPanal/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClientST(int id)
        {
            var client = await _context.ClientSTs.FindAsync(id);
            if (client == null)
            {
                return NotFound();
            }

            _context.ClientSTs.Remove(client);
            await _context.SaveChangesAsync();

            return NoContent();
        }
        // PATCH: api/PAfinanceTCH/5/SetFinanceTrue
        [HttpPatch("{id}/SetFinanceTrue")]
        public async Task<IActionResult> SetFinanceTrue(int id)
        {
            var client = await _context.ClientSTs.FindAsync(id);
            if (client == null)
            {
                return NotFound();
            }

            client.Finance = true;

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
            var client = await _context.ClientSTs.FindAsync(id);
            if (client == null)
            {
                return NotFound();
            }

            client.Partner = true;

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
            return _context.ClientSTs.Any(e => e.CID == id);
        }

    }
}