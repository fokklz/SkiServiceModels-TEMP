using Newtonsoft.Json;
using SkiServiceModels.Attributes;
using SkiServiceModels.BSON.DTOs.Responses.Base;
using SkiServiceModels.BSON.Interfaces;
using SkiServiceModels.BSON.Models;
using SkiServiceModels.Interfaces;
using SkiServiceModels.Interfaces.Models;
using System.Diagnostics.CodeAnalysis;

namespace SkiServiceModels.BSON.DTOs.Responses
{
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    [ModelType(typeof(Priority))]
    public class PriorityResponse : ModelResponse, IPriority, IResponseDTO
    {
        [AllowNull, NotNull]
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("days")]
        public int Days { get; set; }

        int? IPriorityBase.Days { 
            get => Days; 
            set => Days = value ?? 0; 
        }
    }
}
