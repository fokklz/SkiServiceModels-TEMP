using SkiServiceModels.DTOs;
using SkiServiceModels.Interfaces.Models;
using System.Diagnostics.CodeAnalysis;

namespace SkiServiceModels.Common
{
    public class RefreshResultBase<T>
        where T : class, IUserBase
    {
        [AllowNull, NotNull]
        public TokenData TokenData { get; set; }
        [AllowNull, NotNull]
        public T User { get; set; }
    }
}
