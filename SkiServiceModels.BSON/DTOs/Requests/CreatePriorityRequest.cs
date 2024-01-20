using Newtonsoft.Json;
using SkiServiceModels.BSON.DTOs.Requests.Base;
using SkiServiceModels.BSON.Interfaces;

namespace SkiServiceModels.BSON.DTOs.Requests
{
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class CreatePriorityRequest : CreateRequest, IPriority
    {
        [JsonProperty("days")]
        public int Days { get; set; }

        [JsonProperty("name")]
        public required string Name { get; set; }
    }
}
