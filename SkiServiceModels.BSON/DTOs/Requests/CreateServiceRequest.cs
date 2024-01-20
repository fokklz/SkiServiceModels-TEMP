using Newtonsoft.Json;
using SkiServiceModels.BSON.DTOs.Requests.Base;
using SkiServiceModels.BSON.Interfaces;

namespace SkiServiceModels.BSON.DTOs.Requests
{
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
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
