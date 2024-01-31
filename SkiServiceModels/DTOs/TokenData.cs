using Newtonsoft.Json;
using SkiServiceModels.Interfaces;

namespace SkiServiceModels.DTOs
{
    public class TokenData : IDTO
    {
        [JsonProperty("token")]
        public required string Token { get; set; }
        [JsonProperty("refresh_token")]
        public string? RefreshToken { get; set; }
        [JsonProperty("token_type")]
        public string TokenType { get; set; } = "Bearer";
        [JsonProperty("issued")]
        public DateTime Issued { get; set; } = DateTime.UtcNow;
        [JsonProperty("expires")]
        public DateTime Expires { get; set; }
    }
}
