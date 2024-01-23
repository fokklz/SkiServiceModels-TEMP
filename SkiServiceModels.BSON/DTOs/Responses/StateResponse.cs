using Newtonsoft.Json;
using SkiServiceModels.Attributes;
using SkiServiceModels.BSON.DTOs.Responses.Base;
using SkiServiceModels.BSON.Interfaces;
using SkiServiceModels.BSON.Models;
using SkiServiceModels.Interfaces;
using System.Diagnostics.CodeAnalysis;

namespace SkiServiceModels.BSON.DTOs.Responses
{
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    [ModelType(typeof(State))]
    public class StateResponse : ModelResponse, IState, IResponseDTO
    {
        [AllowNull, NotNull]
        public string Name { get; set; }
    }
}
