using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using SkiServiceModels.BSON.Interfaces;
using SkiServiceModels.BSON.Models.Base;
using System.Diagnostics.CodeAnalysis;

namespace SkiServiceModels.BSON.Models
{
    public class Order : Model, IOrder
    {
        [BsonElement("name")]
        [AllowNull, NotNull]
        public string Name { get; set; }

        [BsonElement("email")]
        [AllowNull, NotNull]
        public string Email { get; set; }

        [BsonElement("phone")]
        [AllowNull, NotNull]
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
        [AllowNull, NotNull]
        public virtual IPriority Priority { get; set; }
        public bool ShouldSerializePriority() => false;

        [BsonElement("service")]
        [AllowNull, NotNull]
        public virtual IService Service { get; set; }
        public bool ShouldSerializeService() => false;

        [BsonElement("state")]
        [AllowNull, NotNull]
        public virtual IState State { get; set; }
        public bool ShouldSerializeState() => false;

        [BsonElement("user")]
        public virtual IUser? User { get; set; }
        public bool ShouldSerializeUser() => false;

        [BsonElement("created")]
        public DateTime Created { get; set; } = DateTime.Now;

        [BsonElement("note")]
        public string? Note { get; set; }
    }
}
