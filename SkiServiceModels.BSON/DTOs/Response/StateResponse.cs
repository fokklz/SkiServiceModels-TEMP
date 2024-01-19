using Newtonsoft.Json;
using SkiServiceModels.BSON.DTOs.Response.Base;
using SkiServiceModels.BSON.Interfaces;
using SkiServiceModels.Interfaces;
using System.Diagnostics.CodeAnalysis;

namespace SkiServiceModels.BSON.DTOs.Response
{
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class StateResponse : ModelResponse, IState, IResponseDTO
    {
        [AllowNull, NotNull]
        public string Name { get; set; }
    }
}
