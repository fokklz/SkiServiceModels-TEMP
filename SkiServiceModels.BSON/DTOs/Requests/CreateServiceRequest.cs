using Newtonsoft.Json;
using SkiServiceModels.Attributes;
using SkiServiceModels.BSON.DTOs.Requests.Base;
using SkiServiceModels.BSON.Interfaces;
using SkiServiceModels.BSON.Models;
using System.ComponentModel.DataAnnotations;

namespace SkiServiceModels.BSON.DTOs.Requests
{
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    [ModelType(typeof(Service))]
    public class CreateServiceRequest : CreateRequest, IService
    {

        [JsonProperty("description")]
        [MinLength(20, ErrorMessage = "The description must at least 20 characters long.")]
        public required string Description { get; set; }


        [JsonProperty("name")]
        [MinLength(3, ErrorMessage = "Name must be at least 3 characters long.")]
        public required string Name { get; set; }


        [JsonProperty("price")]
        [Range(1, 1000, ErrorMessage = "The price must be between 1 and 1000.")]
        public int Price { get; set; }
    }
}
