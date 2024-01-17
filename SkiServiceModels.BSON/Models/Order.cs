using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using SkiServiceModels.BSON.Interfaces;
using SkiServiceModels.BSON.Models.Base;

namespace SkiServiceModels.BSON.Models
{
    public class Order : Model, IOrder
    {
        [BsonElement("name")]
        public string Name { get; set; }

        [BsonElement("email")]
        public string Email { get; set; }

        [BsonElement("phone")]
        public string Phone { get; set; }

        [BsonElement("priority_id")]
        public ObjectId PriorityId { get; set; }

        [BsonElement("service_id")]
        public ObjectId ServiceId { get; set; }

        [BsonElement("state_id")]
        public ObjectId StateId { get; set; }

        [BsonElement("user_id")]
        public ObjectId? UserId { get; set; } = null;

        [BsonElement("priority")]
        public virtual Priority Priority { get; set; }
        public bool ShouldSerializePriority() => false;

        [BsonElement("service")]
        public virtual Service Service { get; set; }
        public bool ShouldSerializeService() => false;

        [BsonElement("state")]
        public virtual State State { get; set; }
        public bool ShouldSerializeState() => false;

        [BsonElement("user")]
        public virtual User? User { get; set; }
        public bool ShouldSerializeUser() => false;

        [BsonElement("created")]
        public DateTime Created { get; set; }

        [BsonElement("note")]
        public string? Note { get; set; }
    }
}
