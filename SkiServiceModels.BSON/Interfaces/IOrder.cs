using MongoDB.Bson;
using SkiServiceModels.Interfaces.Models;

namespace SkiServiceModels.BSON.Interfaces
{
    public interface IOrder : IModel, IOrderBase
    {
        ObjectId PriorityId { get; set; }
        ObjectId ServiceId { get; set; }
        ObjectId StateId { get; set; }
        ObjectId? UserId { get; set; }

        IUser? User { get; set; }
        IState State { get; set; }
        IPriority Priority { get; set; }
        IService Service { get; set; }

    }
}
