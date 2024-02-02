using Newtonsoft.Json;
using SkiServiceModels.EF.DTOs.Responses.Base;
using SkiServiceModels.EF.Interfaces;
using SkiServiceModels.Interfaces;
using System.Diagnostics.CodeAnalysis;

namespace SkiServiceModels.EF.DTOs.Responses
{
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class ServiceResponse : ModelResponse, IService, IResponseDTO
    {
        [AllowNull, NotNull]
        public string Description { get; set; }
        [AllowNull, NotNull]
        public string Name { get; set; }
        [AllowNull, NotNull]
        public int? Price { get; set; }
    }
}
