using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using SkiServiceModels.Attributes;
using SkiServiceModels.BSON.DTOs.Requests;
using SkiServiceModels.BSON.Interfaces;
using SkiServiceModels.BSON.Models.Base;
using System.Diagnostics.CodeAnalysis;

namespace SkiServiceModels.BSON.Models
{
    [CreateType(typeof(CreatePriorityRequest))]
    [UpdateType(typeof(UpdatePriorityRequest))]
    public class Priority : Model, IPriority
    {
        [BsonElement("days")]
        public int Days { get; set; }

        [BsonElement("name")]
        [AllowNull, NotNull]
        public string Name { get; set; }
    }
}
