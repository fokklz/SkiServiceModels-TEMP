using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using SkiServiceModels.Attributes;
using SkiServiceModels.BSON.DTOs.Requests.Base;
using SkiServiceModels.Options;
using System.Reflection;

namespace SkiServiceModels.BSON.Extensions
{
    public static class CreateDTOExtension
    {
        public static BsonDocument? Parse<TCreate>(this TCreate create, DTOParseOptions options = null)
            where TCreate : CreateRequest
        {
            options ??= new DTOParseOptions();

            var createDef = new BsonDocument();
            var props = create.GetType().GetProperties();

            if (props == null) return null;

            foreach (var prop in props)
            {
                var propValue = prop.GetValue(create);

                var modelProp = create.GetType().GetCustomAttribute<ModelTypeAttribute>(true);
                var counterPart = modelProp?.ModelType.GetProperties().FirstOrDefault(x => x.Name == prop.Name);

                if (ModelUtils.IsAllowed(counterPart, options) && propValue != null)
                {
                    var bsonElementAttr = counterPart?.GetCustomAttribute<BsonElementAttribute>();
                    var fieldName = bsonElementAttr?.ElementName ?? prop.Name;

                    createDef[fieldName] = BsonValue.Create(propValue);
                }
            }

            return createDef;
        }
    }
}
