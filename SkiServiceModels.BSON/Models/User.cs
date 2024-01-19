using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using SkiServiceModels.Attributes;
using SkiServiceModels.BSON.Interfaces;
using SkiServiceModels.BSON.Models.Base;
using SkiServiceModels.Enums;
using System.Diagnostics.CodeAnalysis;

namespace SkiServiceModels.BSON.Models
{
    public class User : Model, IUser
    {

        [BsonElement("username")]
        [AllowNull, NotNull]
        public string Username { get; set; }

        [BsonElement("password_hash")]
        [AllowNull, NotNull]
        [AdminOnly]
        public byte[] PasswordHash { get; set; }

        [BsonElement("password_salt")]
        [AllowNull, NotNull]
        [AdminOnly]
        public byte[] PasswordSalt { get; set; }

        [BsonElement("locked")]
        [AdminOnly]
        public bool Locked { get; set; } = false;

        [BsonElement("role")]
        [BsonRepresentation(BsonType.String)]
        [OwnerOrAdminOnly]
        public RoleNames Role { get; set; } = RoleNames.User;

        [BsonElement("login_attempts")]
        public int LoginAttempts { get; set; } = 0;

        [BsonElement("refresh_token")]
        public string? RefreshToken { get; set; } = null;
    }
}
