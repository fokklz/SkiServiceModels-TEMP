using SkiServiceModels.EF.Interfaces;
using SkiServiceModels.EF.Models.Base;
using SkiServiceModels.Enums;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace SkiServiceModels.EF.Models
{
    public class User : Model, IUser
    {

        [StringLength(50)]
        [AllowNull, NotNull]
        public string Username { get; set; }
        public int LoginAttempts { get; set; } = 0;
        [AllowNull, NotNull]
        public byte[] PasswordHash { get; set; }
        [AllowNull, NotNull]
        public byte[] PasswordSalt { get; set; }
        public string? RefreshToken { get; set; } = null;
        public RoleNames Role { get; set; } = RoleNames.User;
        public bool Locked { get; set; } = false;
    }
}
