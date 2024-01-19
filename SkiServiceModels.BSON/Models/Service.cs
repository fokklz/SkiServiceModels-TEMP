using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using SkiServiceModels.BSON.Interfaces;
using SkiServiceModels.BSON.Models.Base;
using System.Diagnostics.CodeAnalysis;

namespace SkiServiceModels.BSON.Models
{
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
