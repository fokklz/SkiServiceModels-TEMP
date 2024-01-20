using Newtonsoft.Json;
using SkiServiceModels.BSON.DTOs.Responses.Base;
using SkiServiceModels.BSON.Interfaces;
using SkiServiceModels.Interfaces;
using System.Diagnostics.CodeAnalysis;

namespace SkiServiceModels.BSON.DTOs.Responses
{
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class ServiceResponse : ModelResponse, IService, IResponseDTO
    {
        [AllowNull, NotNull]
        public string Description { get; set; }
        [AllowNull, NotNull]
        public string Name { get; set; }
        public int Price { get; set; }
    }
}
