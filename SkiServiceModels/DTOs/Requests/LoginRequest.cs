using SkiServiceModels.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace SkiServiceModels.DTOs.Requests
{
    public class LoginRequest : IAuthRequest
    {
        [Required]
        public required string Username { get; set; }

        [Required]
        public required string Password { get; set; }

        public bool RememberMe { get; set; } = false;
    }
}
