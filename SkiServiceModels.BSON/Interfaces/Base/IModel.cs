using MongoDB.Bson;
using SkiServiceModels.Interfaces;

namespace SkiServiceModels.BSON.Interfaces.Base
{
    public interface IModel : IModelBase
    {
        ObjectId Id { get; set; }
    }
}
