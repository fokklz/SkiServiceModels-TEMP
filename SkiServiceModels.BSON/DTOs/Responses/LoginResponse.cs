using SkiServiceModels.DTOs;

namespace SkiServiceModels.BSON.DTOs.Responses
{
    public class LoginResponse : UserResponse
    {
        public required TokenData Auth { get; set; }
    }
}
