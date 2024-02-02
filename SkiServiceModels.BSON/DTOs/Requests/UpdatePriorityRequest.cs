using Newtonsoft.Json;
using SkiServiceModels.Attributes;
using SkiServiceModels.BSON.DTOs.Requests.Base;
using SkiServiceModels.BSON.Interfaces;
using SkiServiceModels.BSON.Models;
using SkiServiceModels.Interfaces.Models;
using System.Diagnostics.CodeAnalysis;

namespace SkiServiceModels.BSON.DTOs.Requests
{
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    [ModelType(typeof(Priority))]
    public class UpdatePriorityRequest : UpdateRequest, IPriority
    {
        [JsonProperty("days")]
        public int? Days { get; set; } = null;

        [JsonProperty("name")]
        public string? Name { get; set; } = null;

        // Implemented properties but with allowed null values

        string IPriorityBase.Name
        {
            get => Name ?? string.Empty;
            set => Name = value;
        }

        int IPriorityBase.Days
        {
            get => Days ?? 0;
            set => Days = value;
        }
    }
}
