﻿using System.Collections.Generic;
using System.Security.Claims;
using VinylAppApi.Library.Models.AuthorizationModels;

namespace VinylAppApi.Library.AuthorizationManager
{
    public interface IAuthService
    {
        string SecretKey { get; set; }
        bool IsTokenValid(string token);
        string TokenGeneration(IAuthContainerModel model);
        IEnumerable<Claim> GetTokenClaims(string token);
    }
}
