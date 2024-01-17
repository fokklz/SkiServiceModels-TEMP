using MongoDB.Bson;
using SkiServiceModels.Interfaces.Base;

namespace SkiServiceModels.BSON.Interfaces
{
    public interface IModel : IModelBase
    {
        ObjectId Id { get; set; }
    }
}
