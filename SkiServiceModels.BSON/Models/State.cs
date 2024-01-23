using MongoDB.Bson.Serialization.Attributes;
using SkiServiceModels.Attributes;
using SkiServiceModels.BSON.DTOs.Requests;
using SkiServiceModels.BSON.Interfaces;
using SkiServiceModels.BSON.Models.Base;
using System.Diagnostics.CodeAnalysis;

namespace SkiServiceModels.BSON.Models
{
    [CreateType(typeof(CreateStateRequest))]
    [UpdateType(typeof(UpdateStateRequest))]
    public class State : Model, IState
    {
        [BsonElement("name")]
        [AllowNull, NotNull]
        public string Name { get; set; }
    }
}
