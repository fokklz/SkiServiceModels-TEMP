using SkiServiceModels.EF.Interfaces.Base;
using SkiServiceModels.Interfaces.Models;

namespace SkiServiceModels.EF.Interfaces
{
    public interface IOrder : IModel, IOrderBase
    {
        // Foreign keys
        int ServiceId { get; set; }
        int PriorityId { get; set; }
        int StateId { get; set; }
        int? UserId { get; set; }

        // Navigation properties
        IUser? User { get; set; }
        IService Service { get; set; }
        IPriority Priority { get; set; }
        IState State { get; set; }
    }
}
