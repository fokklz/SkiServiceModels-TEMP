using MongoDB.Bson.Serialization.Attributes;
using SkiServiceModels.BSON.Interfaces;
using SkiServiceModels.BSON.Models.Base;
using System.Diagnostics.CodeAnalysis;

namespace SkiServiceModels.BSON.Models
{
    public class State : Model, IState
    {
        [BsonElement("name")]
        [AllowNull, NotNull]
        public string Name { get; set; }
    }
}
