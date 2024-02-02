using Newtonsoft.Json;
using SkiServiceModels.Attributes;
using SkiServiceModels.BSON.DTOs.Requests.Base;
using SkiServiceModels.BSON.Interfaces;
using SkiServiceModels.BSON.Models;
using SkiServiceModels.Enums;
using SkiServiceModels.Interfaces.Models;
using System.Diagnostics.CodeAnalysis;

namespace SkiServiceModels.BSON.DTOs.Requests
{
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    [ModelType(typeof(User))]
    public class UpdateUserRequest : UpdateRequest, IUser
    {
        [JsonProperty("role")]
        public RoleNames? Role { get; set; } = null;

        [AllowNull]
        [JsonProperty("username")]
        public string Username { get; set; } = null;

        [JsonProperty("locked")]
        public bool? Locked { get; set; } = null;

        [JsonProperty("password")]
        public string? Password { get; set; } = null;

        // Implemented properties but with allowed null values

        bool IUserBase.Locked
        {
            get => Locked ?? false;
            set => Locked = value;
        }

        RoleNames IUserBase.Role
        {
            get => Role ?? RoleNames.User;
            set => Role = value;
        }

        // Hidden properties since they are not allowed to be updated

        int IUserBase.LoginAttempts { get; set; }
        string? IUserBase.RefreshToken { get; set; }
        [AllowNull]
        byte[] IUserBase.PasswordHash { get; set; }
        [AllowNull]
        byte[] IUserBase.PasswordSalt { get; set; }
    }
}
