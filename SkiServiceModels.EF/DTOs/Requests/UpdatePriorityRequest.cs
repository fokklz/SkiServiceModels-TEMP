using Newtonsoft.Json;
using SkiServiceModels.EF.DTOs.Requests.Base;
using SkiServiceModels.EF.Interfaces;
using SkiServiceModels.Interfaces.Models;
using System.Diagnostics.CodeAnalysis;

namespace SkiServiceModels.EF.DTOs.Requests
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
