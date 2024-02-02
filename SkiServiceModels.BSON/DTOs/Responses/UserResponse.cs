using Newtonsoft.Json;
using SkiServiceModels.Attributes;
using SkiServiceModels.BSON.DTOs.Responses.Base;
using SkiServiceModels.BSON.Interfaces;
using SkiServiceModels.BSON.Models;
using SkiServiceModels.Enums;
using SkiServiceModels.Interfaces;
using SkiServiceModels.Interfaces.Models;
using System.Diagnostics.CodeAnalysis;

namespace SkiServiceModels.BSON.DTOs.Responses
{
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    [ModelType(typeof(User))]
    public class UserResponse : ModelResponse, IUser, IResponseDTO
    {
        [AllowNull, NotNull]
        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("locked")]
        public bool? Locked { get; set; }

        [JsonProperty("role")]
        public string? Role { get; set; }

        // Specially implemented properties to allow for null values and parsing

        bool IUserBase.Locked
        {
            get => Locked ?? false;
            set => Locked = value;
        }

        RoleNames IUserBase.Role
        {
            get => Role == null ? RoleNames.User : (RoleNames)Enum.Parse(typeof(RoleNames), Role);
            set => Role = value.ToString();
        }

        // Hidden properties since they are not allowed to be displayed

        [AllowNull]
        byte[] IUserBase.PasswordHash { get; set; }
        [AllowNull]
        byte[] IUserBase.PasswordSalt { get; set; }
        string? IUserBase.RefreshToken { get; set; }
        int IUserBase.LoginAttempts { get; set; }
    }
}
