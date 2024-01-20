using Newtonsoft.Json;
using SkiServiceModels.EF.DTOs.Requests.Base;
using SkiServiceModels.EF.Interfaces;
using System.Diagnostics.CodeAnalysis;

namespace SkiServiceModels.EF.DTOs.Requests
{
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class UpdateStateRequest : UpdateRequest, IState
    {
        [AllowNull]
        public string Name { get; set; } = null;
    }
}
