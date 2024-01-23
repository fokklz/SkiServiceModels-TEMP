using Newtonsoft.Json;
using SkiServiceModels.Attributes;
using SkiServiceModels.BSON.DTOs.Requests.Base;
using SkiServiceModels.BSON.Interfaces;
using SkiServiceModels.BSON.Models;

namespace SkiServiceModels.BSON.DTOs.Requests
{
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    [ModelType(typeof(Service))]
    public class CreateServiceRequest : CreateRequest, IService
    {

        [JsonProperty("description")]
        public required string Description { get; set; }


        [JsonProperty("name")]
        public required string Name { get; set; }


        [JsonProperty("price")]
        public int Price { get; set; }
    }
}
