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
    [ModelType(typeof(State))]
    public class UpdateStateRequest : UpdateRequest, IState
    {
        [JsonProperty("name")]
        [MinLength(3, ErrorMessage = "Name must be at least 3 characters long.")]
        public string? Name { get; set; } = null;

        // Implemented properties but with allowed null values

        string IStateBase.Name
        {
            get => Name ?? string.Empty;
            set => Name = value;
        }
    }
}
