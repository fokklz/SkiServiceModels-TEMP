using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using SkiServiceModels.BSON.Interfaces;
using SkiServiceModels.BSON.Models.Base;

namespace SkiServiceModels.BSON.Models
{
    public class Priority : Model, IPriority
    {
        [BsonElement("days")]
        public int Days { get; set; }

        [BsonElement("name")]
        public string Name { get; set; }
    }
}
