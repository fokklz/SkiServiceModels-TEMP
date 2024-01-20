using Newtonsoft.Json;
using SkiServiceModels.BSON.DTOs.Requests.Base;
using SkiServiceModels.BSON.Interfaces;
using System.Diagnostics.CodeAnalysis;

namespace SkiServiceModels.BSON.DTOs.Requests
{
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class UpdateStateRequest : UpdateRequest, IState
    {
        [AllowNull]
        public string Name { get; set; } = null;
    }
}
