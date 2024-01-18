using SkiServiceModels.BSON.DTOs.Response.Base;
using SkiServiceModels.BSON.Interfaces;
using SkiServiceModels.Interfaces;
using System.Diagnostics.CodeAnalysis;

namespace SkiServiceModels.BSON.DTOs.Response
{
    public class StateResponse : ModelResponse, IState, IResponseDTO
    {
        [AllowNull, NotNull]
        public string Name { get; set; }
    }
}
