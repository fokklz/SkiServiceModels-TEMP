using Newtonsoft.Json;
using SkiServiceModels.Attributes;
using SkiServiceModels.BSON.DTOs.Requests.Base;
using SkiServiceModels.BSON.Interfaces;
using SkiServiceModels.BSON.Models;
using SkiServiceModels.Interfaces.Models;
using System.Diagnostics.CodeAnalysis;

namespace SkiServiceModels.BSON.DTOs.Requests
{
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    [ModelType(typeof(Service))]
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
