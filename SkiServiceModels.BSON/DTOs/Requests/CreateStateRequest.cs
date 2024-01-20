using Newtonsoft.Json;
using SkiServiceModels.BSON.DTOs.Requests.Base;
using SkiServiceModels.BSON.Interfaces;

namespace SkiServiceModels.BSON.DTOs.Requests
{
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class CreateStateRequest : CreateRequest, IState
    {
        [JsonProperty("name")]
        public required string Name { get; set; }
    }
}
