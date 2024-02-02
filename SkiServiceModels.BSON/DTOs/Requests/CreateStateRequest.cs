using Newtonsoft.Json;
using SkiServiceModels.Attributes;
using SkiServiceModels.BSON.DTOs.Requests.Base;
using SkiServiceModels.BSON.Interfaces;
using SkiServiceModels.BSON.Models;
using System.ComponentModel.DataAnnotations;

namespace SkiServiceModels.BSON.DTOs.Requests
{
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    [ModelType(typeof(State))]
    public class CreateStateRequest : CreateRequest, IState
    {
        [JsonProperty("name")]
        [MinLength(3, ErrorMessage = "Name must be at least 3 characters long.")]
        public required string Name { get; set; }
    }
}
