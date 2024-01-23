using SkiServiceModels.DTOs;
using SkiServiceModels.Interfaces;
using System.Diagnostics.CodeAnalysis;

namespace SkiServiceModels.EF.Models
{
    public class RefreshResult : IRefreshRequest<User>
    {
        [AllowNull, NotNull]
        public User User { get; set; }
        [AllowNull, NotNull]
        public TokenData TokenData { get; set; }
    }
}
