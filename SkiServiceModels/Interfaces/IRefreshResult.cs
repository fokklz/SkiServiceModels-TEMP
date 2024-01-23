using SkiServiceModels.DTOs;
using SkiServiceModels.Interfaces.Models;

namespace SkiServiceModels.Interfaces
{
    public interface IRefreshRequest<T>
        where T : class, IUserBase
    {
        public T User { get; set; }
        public TokenData TokenData { get; set; }
    }
}
