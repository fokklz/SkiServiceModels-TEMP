using SkiServiceModels.DTOs;
using SkiServiceModels.Interfaces;

namespace SkiServiceModels.BSON.Models
{
    public class RefreshResult : IRefreshRequest<User>
    {
        public required User User { get; set; }
        public required TokenData TokenData { get; set; }
    }
}
