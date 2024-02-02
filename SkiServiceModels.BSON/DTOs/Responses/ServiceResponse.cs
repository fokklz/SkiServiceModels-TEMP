using Newtonsoft.Json;
using SkiServiceModels.Attributes;
using SkiServiceModels.BSON.DTOs.Responses.Base;
using SkiServiceModels.BSON.Interfaces;
using SkiServiceModels.BSON.Models;
using SkiServiceModels.Interfaces;
using System.Diagnostics.CodeAnalysis;

namespace SkiServiceModels.BSON.DTOs.Responses
{
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    [ModelType(typeof(Service))]
    public class ServiceResponse : ModelResponse, IService, IResponseDTO
    {
        [AllowNull, NotNull]
        [JsonProperty("description")]   
        public string Description { get; set; }

        [AllowNull, NotNull]
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("price")]
        public int? Price { get; set; }
    }
}
