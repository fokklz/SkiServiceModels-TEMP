using Newtonsoft.Json;
using SkiServiceModels.EF.DTOs.Requests.Base;
using SkiServiceModels.EF.Interfaces;

namespace SkiServiceModels.EF.DTOs.Requests
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
