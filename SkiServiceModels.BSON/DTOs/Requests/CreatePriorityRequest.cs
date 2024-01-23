using Newtonsoft.Json;
using SkiServiceModels.Attributes;
using SkiServiceModels.BSON.DTOs.Requests.Base;
using SkiServiceModels.BSON.Interfaces;
using SkiServiceModels.BSON.Models;

namespace SkiServiceModels.BSON.DTOs.Requests
{
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    [ModelType(typeof(Priority))]
    public class CreatePriorityRequest : CreateRequest, IPriority
    {
        [JsonProperty("days")]
        public int Days { get; set; }

        [JsonProperty("name")]
        public required string Name { get; set; }
    }
}
