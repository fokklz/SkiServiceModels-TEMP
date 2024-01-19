﻿using Newtonsoft.Json;
using SkiServiceModels.BSON.DTOs.Request.Base;
using SkiServiceModels.BSON.Interfaces;
using SkiServiceModels.Enums;
using SkiServiceModels.Interfaces.Models;
using System.Diagnostics.CodeAnalysis;

namespace SkiServiceModels.BSON.DTOs.Request
{
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class CreateUserRequest : CreateRequest, IUser
    {
        [JsonProperty("role")]
        public RoleNames Role { get; set; }

        [JsonProperty("username")]
        public required string Username { get; set; } 

        // Hidden properties since they are not allowed to be updated

        int IUserBase.LoginAttempts { get; set; }
        string? IUserBase.RefreshToken { get; set; }
        [AllowNull]
        byte[] IUserBase.PasswordHash { get; set; }
        [AllowNull]
        byte[] IUserBase.PasswordSalt { get; set; }
        bool IUserBase.Locked { get; set; }
    }
}
