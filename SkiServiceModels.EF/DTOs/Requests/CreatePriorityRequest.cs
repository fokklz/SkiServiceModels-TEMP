using Newtonsoft.Json;
using SkiServiceModels.EF.DTOs.Requests.Base;
using SkiServiceModels.EF.Interfaces;
using SkiServiceModels.Interfaces.Models;

namespace SkiServiceModels.EF.DTOs.Requests
{
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class CreatePriorityRequest : CreateRequest, IPriority
    {
        [JsonProperty("days")]
        public int Days { get; set; }

        [JsonProperty("name")]
        public required string Name { get; set; }

        int? IPriorityBase.Days
        {
            get => Days;
            set => Days = value ?? 0;
        }
    }
}
