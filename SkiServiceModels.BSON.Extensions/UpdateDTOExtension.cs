using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using SkiServiceModels.Attributes;
using SkiServiceModels.BSON.DTOs.Requests.Base;
using SkiServiceModels.Options;
using System.Reflection;

namespace SkiServiceModels.BSON.Extensions
{
    public static class UpdateDTOExtension
    {
        public static UpdateDefinition<BsonDocument>? Parse<TUpdate>(this TUpdate update, DTOParseOptions options = null)
            where TUpdate : UpdateRequest
        {
            options ??= new DTOParseOptions();

            var updateDefs = new List<UpdateDefinition<BsonDocument>>();
            var props = update.GetType().GetProperties();

            if (props == null) return null;

            foreach (var prop in props)
            {
                var propValue = prop.GetValue(update);

                var modelProp = update.GetType().GetCustomAttribute<ModelTypeAttribute>(true);
                var counterPart = modelProp?.ModelType.GetProperties().FirstOrDefault(x => x.Name == prop.Name);

                if(ModelUtils.IsAllowed(counterPart, options) && propValue == null)
                {
                    var bsonElementAttr = counterPart?.GetCustomAttribute<BsonElementAttribute>();
                    var fieldName = bsonElementAttr?.ElementName ?? prop.Name;

                    updateDefs.Add(Builders<BsonDocument>.Update.Set(fieldName, propValue));
                }
            }

            return Builders<BsonDocument>.Update.Combine(updateDefs);
        }
    }
}
