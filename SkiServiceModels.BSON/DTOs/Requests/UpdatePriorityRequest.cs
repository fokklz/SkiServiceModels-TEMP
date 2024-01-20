using Newtonsoft.Json;
using SkiServiceModels.BSON.DTOs.Requests.Base;
using SkiServiceModels.BSON.Interfaces;
using SkiServiceModels.Interfaces.Models;
using System.Diagnostics.CodeAnalysis;

namespace SkiServiceModels.BSON.DTOs.Requests
{
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class UpdatePriorityRequest : UpdateRequest, IPriority
    {
        [JsonProperty("days")]
        public int? Days { get; set; } = null;

        [AllowNull]
        [JsonProperty("name")]
        public string Name { get; set; } = null;

        // Implemented properties but with allowed null values

        int IPriorityBase.Days
        {
            get => Days ?? 0;
            set => Days = value;
        }
    }
}
