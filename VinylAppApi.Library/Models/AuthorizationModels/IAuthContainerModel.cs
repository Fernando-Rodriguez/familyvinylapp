﻿using System.Security.Claims;

namespace VinylAppApi.Library.Models.AuthorizationModels
{
    public interface IAuthContainerModel
    {
        string SecretKey { get; }
        string SecurityAlgorithm { get; set; }
        int ExpireMinutes { get; set; }
        Claim[] Claims { get; set; }
    }
}