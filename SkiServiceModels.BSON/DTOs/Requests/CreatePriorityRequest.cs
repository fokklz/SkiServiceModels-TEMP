using Newtonsoft.Json;
using SkiServiceModels.Attributes;
using SkiServiceModels.BSON.DTOs.Requests.Base;
using SkiServiceModels.BSON.Interfaces;
using SkiServiceModels.BSON.Models;
using SkiServiceModels.Interfaces.Models;
using System.ComponentModel.DataAnnotations;

namespace SkiServiceModels.BSON.DTOs.Requests
{
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    [ModelType(typeof(Priority))]
    public class CreatePriorityRequest : CreateRequest, IPriority
    {
        [JsonProperty("days")]
        [Range(1, 365, ErrorMessage = "Days must be between 1 and 365.")]
        public int Days { get; set; }

        [JsonProperty("name")]
        [RegularExpression("^[A-Za-z0-9 ]+$", ErrorMessage = "Name must only contain letters, numbers, and spaces.")]
        public required string Name { get; set; }

        int? IPriorityBase.Days
        {
            get => Days;
            set => Days = value ?? 0;
        }
    }
}
