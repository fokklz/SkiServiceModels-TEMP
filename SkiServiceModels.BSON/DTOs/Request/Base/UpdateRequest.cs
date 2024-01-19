using MongoDB.Bson;
using Newtonsoft.Json;
using SkiServiceModels.BSON.Interfaces;
using SkiServiceModels.Interfaces;
using SkiServiceModels.Interfaces.Base;

namespace SkiServiceModels.BSON.DTOs.Request.Base
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
