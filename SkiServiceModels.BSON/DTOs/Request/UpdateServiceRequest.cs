using Newtonsoft.Json;
using SkiServiceModels.BSON.DTOs.Request.Base;
using SkiServiceModels.BSON.Interfaces;
using SkiServiceModels.Interfaces.Models;
using System.Diagnostics.CodeAnalysis;

namespace SkiServiceModels.BSON.DTOs.Request
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
