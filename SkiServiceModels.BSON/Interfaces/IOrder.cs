using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using SkiServiceModels.Interfaces;

namespace SkiServiceModels.BSON.Interfaces
{
    public interface IOrder : IModel, IOrderBase
    {
        ObjectId PriorityId { get; set; }
        ObjectId ServiceId { get; set; }
        ObjectId StateId { get; set; }
        ObjectId? UserId { get; set; }
    }
}
