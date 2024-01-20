using MongoDB.Bson;
using SkiServiceModels.BSON.Interfaces.Base;
using SkiServiceModels.Interfaces;
using SkiServiceModels.Interfaces.Base;

namespace SkiServiceModels.BSON.DTOs.Requests.Base
{
    public class CreateRequest : IModel, ICreateDTO
    {
        // Hidden properties since they are not allowed to be set when creating
        bool IModelBase.IsDeleted { get; set; }
        ObjectId IModel.Id { get; set; }
    }
}
