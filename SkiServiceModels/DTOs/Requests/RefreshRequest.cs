using Newtonsoft.Json;
using SkiServiceModels.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace SkiServiceModels.DTOs.Requests
{
    public class RefreshRequest : IAuthRequest
    {
        [Required]
        [JsonProperty("token")]
        public required string Token { get; set; }

        [Required]
        [JsonProperty("refresh_token")]
        public required string RefreshToken { get; set; }
    }
}
