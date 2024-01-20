using SkiServiceModels.Interfaces;

namespace SkiServiceModels.DTOs
{
    public class TokenData : IDTO
    {
        public required string Token { get; set; }
        public string? RefreshToken { get; set; }
        public string TokenType { get; set; } = "Bearer";
        public DateTime Issued { get; set; } = DateTime.UtcNow;
        public DateTime Expires { get; set; }
    }
}
