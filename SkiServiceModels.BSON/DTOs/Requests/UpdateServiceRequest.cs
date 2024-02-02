using Newtonsoft.Json;
using SkiServiceModels.Attributes;
using SkiServiceModels.BSON.DTOs.Requests.Base;
using SkiServiceModels.BSON.Interfaces;
using SkiServiceModels.BSON.Models;
using SkiServiceModels.Interfaces.Models;

namespace SkiServiceModels.BSON.DTOs.Requests
{
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    [ModelType(typeof(Service))]
    public class UpdateServiceRequest : UpdateRequest, IService
    {
        [JsonProperty("description")]
        public string? Description { get; set; } = null;

        [JsonProperty("name")]
        public string? Name { get; set; } = null;

        [JsonProperty("price")]
        public int? Price { get; set; } = null;

        // Implemented properties but with allowed null values

        string IServiceBase.Description
        {
            get => Description ?? string.Empty;
            set => Description = value;
        }

        string IServiceBase.Name
        {
            get => Name ?? string.Empty;
            set => Name = value;
        }

        int IServiceBase.Price
        {
            get => Price ?? 0;
            set => Price = value;
        }
    }
}
