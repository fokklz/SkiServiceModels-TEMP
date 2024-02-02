using Newtonsoft.Json;
using SkiServiceModels.EF.DTOs.Responses.Base;
using SkiServiceModels.EF.Interfaces;
using SkiServiceModels.Interfaces;
using SkiServiceModels.Interfaces.Models;
using System.Diagnostics.CodeAnalysis;

namespace SkiServiceModels.EF.DTOs.Responses
{
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class PriorityResponse : ModelResponse, IPriority, IResponseDTO
    {
        [AllowNull, NotNull]
        public string Name { get; set; }
        public int Days { get; set; }

        int? IPriorityBase.Days
        {
            get => Days;
            set => Days = value ?? 0;
        }
    }
}
