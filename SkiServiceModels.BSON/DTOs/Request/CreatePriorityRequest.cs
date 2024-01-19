using Newtonsoft.Json;
using SkiServiceModels.BSON.DTOs.Request.Base;
using SkiServiceModels.BSON.Interfaces;

namespace SkiServiceModels.BSON.DTOs.Request
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
