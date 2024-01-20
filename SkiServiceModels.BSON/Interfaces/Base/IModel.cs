using MongoDB.Bson;
using SkiServiceModels.Interfaces.Base;

namespace SkiServiceModels.BSON.Interfaces.Base
{
    public interface IModel : IModelBase
    {
        ObjectId Id { get; set; }
    }
}
