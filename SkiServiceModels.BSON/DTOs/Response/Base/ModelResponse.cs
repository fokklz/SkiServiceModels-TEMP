using MongoDB.Bson;
using Newtonsoft.Json;
using SkiServiceModels.Attributes;
using SkiServiceModels.BSON.Interfaces;
using SkiServiceModels.Interfaces.Base;

namespace SkiServiceModels.BSON.DTOs.Response.Base
{
    public abstract class ModelResponse : IModel
    {
        public required string Id { get; set; }
        ObjectId IModel.Id
        {
            get => ObjectId.Parse(Id);
            set => Id = value.ToString();
        }

        [AdminOnly]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public bool? IsDeleted { get; set; } = null;

        bool IModelBase.IsDeleted
        {
            get => IsDeleted ?? false;
            set => IsDeleted = value;
        }
    }
}
