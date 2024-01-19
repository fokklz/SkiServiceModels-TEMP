using Newtonsoft.Json;
using SkiServiceModels.BSON.DTOs.Request.Base;
using SkiServiceModels.BSON.Interfaces;

namespace SkiServiceModels.BSON.DTOs.Request
{
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class CreateStateRequest : CreateRequest, IState
    {
        [JsonProperty("name")]
        public required string Name { get; set; }
    }
}
