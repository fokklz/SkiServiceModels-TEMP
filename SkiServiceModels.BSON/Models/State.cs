using MongoDB.Bson.Serialization.Attributes;
using SkiServiceModels.BSON.Interfaces;
using SkiServiceModels.BSON.Models.Base;

namespace SkiServiceModels.BSON.Models
{
    public class State : Model, IState
    {
        [BsonElement("name")]
        public string Name { get; set; }
    }
}
