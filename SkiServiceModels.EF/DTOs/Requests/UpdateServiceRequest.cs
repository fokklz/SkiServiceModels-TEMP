using Newtonsoft.Json;
using SkiServiceModels.EF.DTOs.Requests.Base;
using SkiServiceModels.EF.Interfaces;
using SkiServiceModels.Interfaces.Models;
using System.Diagnostics.CodeAnalysis;

namespace SkiServiceModels.EF.DTOs.Requests
{
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class UpdateServiceRequest : UpdateRequest, IService
    {
        [AllowNull]
        [JsonProperty("description")]
        public string Description { get; set; } = null;

        [AllowNull]
        [JsonProperty("name")]
        public string Name { get; set; } = null;

        [JsonProperty("price")]
        public int? Price { get; set; } = null;

        // Implemented properties but with allowed null values

        int IServiceBase.Price
        {
            get => Price ?? 0;
            set => Price = value;
        }
    }
}
