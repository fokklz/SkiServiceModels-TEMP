using SkiServiceModels.Interfaces;

namespace SkiServiceModels.DTOs
{
    public class ErrorData : IDTO
    {
        public required string Code { get; set; }

        public required string Message { get; set; }
    }
}
