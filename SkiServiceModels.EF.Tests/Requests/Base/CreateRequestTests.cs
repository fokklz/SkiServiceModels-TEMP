using SkiServiceModels.EF.DTOs.Requests.Base;
using SkiServiceModels.EF.Interfaces.Base;

namespace SkiServiceModels.EF.Tests.Requests.Base
{
    public class CreateRequestTests
    {
        [Fact]
        public void ParseAlwaysIgnoresIdAndIsDeleted()
        {
            var rawJson = @"
            {
                ""id"": 1,
                ""is_deleted"": true,
                ""name"": ""Test""
            }";

            var parsed = JsonConvert.DeserializeObject<CreateRequest>(rawJson);

            Assert.NotEqual(1, (parsed as IModel)?.Id);
            Assert.False((parsed as IModel)?.IsDeleted);
        }

    }
}
