using Newtonsoft.Json;
using SkiServiceModels.Interfaces;

namespace SkiServiceModels.DTOs
{
    public class ErrorData : IDTO
    {
        [JsonProperty("code")]
        public required string Code { get; set; }

        [JsonProperty("message")]
        public required string Message { get; set; }
    }
}
