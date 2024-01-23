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
