using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using SkiServiceModels.BSON.Interfaces;

namespace SkiServiceModels.BSON.Models.Base
{
    public class Model : IModel
    {
        [BsonId]
        public ObjectId Id { get; set; }

        [BsonElement("is_deleted")]
        public bool IsDeleted { get; set; } = false;
    }
}
