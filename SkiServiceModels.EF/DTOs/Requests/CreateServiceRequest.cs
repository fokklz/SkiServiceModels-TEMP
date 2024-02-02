using Newtonsoft.Json;
using SkiServiceModels.EF.DTOs.Requests.Base;
using SkiServiceModels.EF.Interfaces;
using SkiServiceModels.Interfaces.Models;

namespace SkiServiceModels.EF.DTOs.Requests
{
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class CreateServiceRequest : CreateRequest, IService
    {

        [JsonProperty("description")]
        public required string Description { get; set; }

        [JsonProperty("name")]
        public required string Name { get; set; }

        [JsonProperty("price")]
        public int Price { get; set; }

        int? IServiceBase.Price
        {
            get => Price;
            set => Price = value ?? 0;
        }
    }
}
