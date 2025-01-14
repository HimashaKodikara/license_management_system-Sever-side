﻿using license_management_system_Sever_side.Models.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace license_management_system_Sever_side.Services.RequestKeySerives
{
    public interface IRequestKeySerives
    {
        public Task AddRequestKey(RequestKeyDto requestKey);
        public Task<IEnumerable<RequestKeyDto>> GetAllrequestkeys();
        //public Task<IEnumerable<RequestKeyDto>> GetAllRequestKeysWithEndClientDetails();
    }
}
