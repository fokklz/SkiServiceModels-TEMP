using MongoDB.Bson;
using SkiServiceModels.BSON.DTOs.Requests.Base;
using SkiServiceModels.BSON.Interfaces.Base;

namespace SkiServiceModels.BSON.Tests.Requests.Base
{
    public class CreateRequestTests
    {
        [Fact]
        public void ParseAlwaysIgnoresIdAndIsDeleted()
        {
            var rawJson = @"
            {
                ""id"": ""5f7b1c3b9b3b2d0d9c9f1b1a"",
                ""is_deleted"": true,
                ""name"": ""Test""
            }";

            var parsed = JsonConvert.DeserializeObject<CreateRequest>(rawJson);

            Assert.Equal((parsed as IModel)?.Id, ObjectId.Empty);
            Assert.False((parsed as IModel)?.IsDeleted);
        }

    }
}
