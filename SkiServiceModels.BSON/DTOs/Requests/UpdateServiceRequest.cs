using Newtonsoft.Json;
using SkiServiceModels.Attributes;
using SkiServiceModels.BSON.DTOs.Requests.Base;
using SkiServiceModels.BSON.Interfaces;
using SkiServiceModels.BSON.Models;
using SkiServiceModels.Interfaces.Models;
using System.ComponentModel.DataAnnotations;

namespace SkiServiceModels.BSON.DTOs.Requests
{
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    [ModelType(typeof(Service))]
    public class UpdateServiceRequest : UpdateRequest, IService
    {
        [JsonProperty("description")]
        [MinLength(20, ErrorMessage = "The description must at least 20 characters long.")]
        public string? Description { get; set; } = null;

        [JsonProperty("name")]
        [MinLength(3, ErrorMessage = "Name must be at least 3 characters long.")]
        public string? Name { get; set; } = null;

        [JsonProperty("price")]
        [Range(1, 1000, ErrorMessage = "The price must be between 1 and 1000.")]
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
