using SkiServiceModels.EF.Interfaces;
using SkiServiceModels.EF.Models.Base;
using SkiServiceModels.Enums;
using System.ComponentModel.DataAnnotations;

namespace SkiServiceModels.EF.Models
{
    public class User : Model, IUser
    {

        [StringLength(50)]
        public string Username { get; set; }
        public int LoginAttempts { get; set; } = 0;
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public string? RefreshToken { get; set; } = null;
        public RoleNames Role { get; set; } = RoleNames.User;
        public bool Locked { get; set; } = false;
    }
}
