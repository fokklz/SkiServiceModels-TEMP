using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using SkiServiceModels.BSON.Interfaces.Base;
using SkiServiceModels.Interfaces;
using System.Reflection;
using SkiServiceModels.BSON.Extensions;
using SkiServiceModels.BSON.DTOs.Requests.Base;
using SkiServiceModels.Attributes;

namespace SkiServiceModels.BSON.Extensions
{
    public static class ModelExtensions
    {
        public static UpdateDefinition<RModel> ToUpdateDefinition<TUpdate, RModel>(this TUpdate update)
            where TUpdate : UpdateRequest
            where RModel : IModel
        {
            var modelType = update.GetType().GetCustomAttributes(false).OfType<ModelTypeAttribute>().FirstOrDefault()?.ModelType;
            var updateDefs = new List<UpdateDefinition<RModel>>();
            var modelProperties = (modelType ?? typeof(TUpdate)).GetProperties();
            var properties = typeof(TUpdate).GetProperties();

            foreach (var item in properties)
            {
                // find the actual property in the model
                var counterPart = modelProperties.FirstOrDefault(x => x.Name.Equals(item.Name));

                var value = item.GetValue(update);
                if (value != null)
                {
                    // skip the id property for any update
                    var bsonIdAttr = counterPart?.GetCustomAttribute<BsonIdAttribute>();
                    if (bsonIdAttr != null) continue;

                    var bsonElementAttr = counterPart?.GetCustomAttribute<BsonElementAttribute>();
                    var fieldName = bsonElementAttr?.ElementName ?? item.Name;

                    updateDefs.Add(Builders<RModel>.Update.Set(fieldName, value));
                }
            }

            return Builders<RModel>.Update.Combine(updateDefs);
        }

        public static UpdateDefinition<TModel> ToUpdateDefinition<TModel>(this UpdateRequest update)
            where TModel : class, IModel
        {
            return ToUpdateDefinition<UpdateRequest, TModel>(update);
        }
    }
}
