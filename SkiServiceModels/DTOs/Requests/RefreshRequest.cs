using SkiServiceModels.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace SkiServiceModels.DTOs.Requests
{
    public class RefreshRequest : IAuthRequest
    {
        [Required]
        public required string Token { get; set; }

        [Required]
        public required string RefreshToken { get; set; }
    }
}
