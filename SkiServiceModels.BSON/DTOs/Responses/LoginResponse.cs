using Newtonsoft.Json;
using SkiServiceModels.DTOs;

namespace SkiServiceModels.BSON.DTOs.Responses
{
    public class LoginResponse : UserResponse
    {
        [JsonProperty("auth")]
        public required TokenData Auth { get; set; }
    }
}
