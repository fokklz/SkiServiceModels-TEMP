using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using SkiServiceModels.Attributes;
using SkiServiceModels.BSON.DTOs.Requests;
using SkiServiceModels.BSON.Interfaces;
using SkiServiceModels.BSON.Models.Base;
using System.Diagnostics.CodeAnalysis;

namespace SkiServiceModels.BSON.Models
{
    [CreateType(typeof(CreateServiceRequest))]
    [UpdateType(typeof(UpdateServiceRequest))]
    public class Service : Model, IService
    {
        [BsonElement("description")]
        [AllowNull, NotNull]
        public string Description { get; set; }

        [BsonElement("name")]
        [AllowNull, NotNull]
        public string Name { get; set; }

        [BsonElement("price")]
        public int Price { get; set; }
    }
}
