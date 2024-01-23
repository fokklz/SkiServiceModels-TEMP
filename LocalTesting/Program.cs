using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using SkiServiceModels.Attributes;
using SkiServiceModels.BSON.DTOs.Requests;
using SkiServiceModels.BSON.DTOs.Requests.Base;
using SkiServiceModels.BSON.Interfaces.Base;
using System.Reflection;

namespace LocalTesting
{
    public static class  Extensions { 
    
        public static UpdateDefinition<BsonDocument> Serialize<TUpdate>(this TUpdate update)
            where TUpdate : UpdateRequest
        {
            var updateDefs = new List<UpdateDefinition<BsonDocument>>();
            var props = update?.GetType().GetProperties();

            if (props == null || update == null) return new BsonDocument();

            foreach (var prop in props)
            {
                var propValue = prop.GetValue(update);

                var modelProp = update.GetType().GetCustomAttribute<ModelTypeAttribute>(true);
                var counterPart = modelProp?.ModelType.GetProperties().FirstOrDefault(x => x.Name == prop.Name);

                if (propValue != null) // Add null check for property value
                {
                    var bsonElementAttr = counterPart?.GetCustomAttribute<BsonElementAttribute>();
                    var fieldName = bsonElementAttr?.ElementName ?? prop.Name;

                    updateDefs.Add(Builders<BsonDocument>.Update.Set(fieldName, propValue));
                }
            }

            return Builders<BsonDocument>.Update.Combine(updateDefs);
        }

        public static FilterDefinition<BsonDocument> GetIdFilter<TModel>(this TModel model)
            where TModel : IModel
        {
            return Builders<BsonDocument>.Filter.Eq("_id", model.Id);
        }

    }

    internal class Program
    {
        static void Main(string[] args)
        {

            var state = new UpdateOrderRequest()
            {
                Name = "Test",
                Email = "DSADSD",
                Phone = "DSADSD",
                ServiceId = ObjectId.GenerateNewId().ToString(),
            };
            state.GetIdFilter();


            var serializer = BsonSerializer.SerializerRegistry.GetSerializer<BsonDocument>();
            if (serializer == null) // Add null check for serializer
            {
                Console.WriteLine("Serializer for State could not be found.");
                return;
            }

            var bsonDocument = state.Serialize().Render(serializer, BsonSerializer.SerializerRegistry);

            Console.WriteLine(bsonDocument);
        }
    }
}
