using SkiServiceModels.DTOs;

namespace SkiServiceModels.EF.DTOs.Responses
{
    public class LoginResponse : UserResponse
    {
        public required TokenData Auth { get; set; }
    }
}
