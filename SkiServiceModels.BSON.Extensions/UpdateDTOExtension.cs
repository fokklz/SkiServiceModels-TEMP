using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using SkiServiceModels.Attributes;
using SkiServiceModels.BSON.DTOs.Requests.Base;
using SkiServiceModels.BSON.Interfaces.Base;
using SkiServiceModels.Options;
using System.Reflection;

namespace SkiServiceModels.BSON.Extensions
{
    public static class UpdateDTOExtension
    {
        public static UpdateDefinition<TModel>? Parse<TUpdate, TModel>(this TUpdate update, DTOParseOptions options = null)
            where TUpdate : UpdateRequest
            where TModel : class, IModel
        {
            options ??= new DTOParseOptions();

            var updateDefs = new List<UpdateDefinition<TModel>>();
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

                    updateDefs.Add(Builders<TModel>.Update.Set(fieldName, propValue));
                }
            }

            return Builders<TModel>.Update.Combine(updateDefs);
        }
    }
}
