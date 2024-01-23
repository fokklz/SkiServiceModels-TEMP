using MongoDB.Bson;
using Newtonsoft.Json;
using SkiServiceModels.BSON.Interfaces.Base;
using SkiServiceModels.Interfaces;

namespace SkiServiceModels.BSON.DTOs.Requests.Base
{
    public class UpdateRequest : IModel, IUpdateDTO
    {
        [JsonProperty("is_deleted")]
        public bool? IsDeleted { get; set; } = null;

        // Implemented properties but with allowed null values

        bool IModelBase.IsDeleted
        {
            get => IsDeleted ?? false;
            set => IsDeleted = value;
        }

        // Hidden properties since they are not allowed to be updated

        ObjectId IModel.Id { get; set; }
    }
}
