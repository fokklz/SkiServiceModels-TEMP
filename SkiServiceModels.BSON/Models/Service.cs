using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using SkiServiceModels.BSON.Interfaces;
using SkiServiceModels.BSON.Models.Base;

namespace SkiServiceModels.BSON.Models
{
    public class Service : Model, IService
    {
        [BsonElement("description")]
        public string Description { get; set; }

        [BsonElement("name")]
        public string Name { get; set; }

        [BsonElement("price")]
        public int Price { get; set; }
    }
}
