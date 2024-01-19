using MongoDB.Bson;
using SkiServiceModels.BSON.DTOs.Request;
using SkiServiceModels.BSON.Models;

namespace SkiServiceModels.BSON.Tests.Requests
{
    public class CreateServiceRequestTests
    {
        private readonly IMapper _mapper = AutoMapperFactory.Create();

        [Fact]
        public void ParseToService_IgnoresIdAndIsDeleted_ForNoneAdmins()
        {
            var requestJson = @"{
                ""id"": ""5f9d7a9d9d9d9d9d9d9d9d9"",
                ""is_deleted"": true,
                ""name"": ""Test"",
                ""description"": ""Test"",
                ""price"": 100
            }";

            var parsed = JsonConvert.DeserializeObject<CreateServiceRequest>(requestJson);
            var response = _mapper.Map<Service>(parsed);

            Assert.Equal(response.Id, ObjectId.Empty);
            Assert.False(response.IsDeleted);
        }

        [Fact]
        public void ParseToService_IgnoresIdAndIsDeleted_ForAdmins()
        {
            var requestJson = @"{
                ""id"": ""5f9d7a9d9d9d9d9d9d9d9d9"",
                ""is_deleted"": true,
                ""name"": ""Test"",
                ""description"": ""Test"",
                ""price"": 100
            }";

            var parsed = JsonConvert.DeserializeObject<CreateServiceRequest>(requestJson);
            var response = _mapper.Map<Service>(parsed, opts =>
            {
                opts.Items["IsAdmin"] = true;
            });

            Assert.Equal(response.Id, ObjectId.Empty);
            Assert.False(response.IsDeleted);
        }

        [Fact]
        public void MapToService_IncludeAllProperties_ForNoneAdmins()
        {
            var request = new CreateServiceRequest
            {
                Name = "Test",
                Description = "Test",
                Price = 100,
            };

            var mapped = _mapper.Map<Service>(request);

            Assert.Equal(mapped.Name, request.Name);
            Assert.Equal(mapped.Description, request.Description);
            Assert.Equal(mapped.Price, request.Price);
        }

        [Fact]
        public void MapToService_IncludeAllProperties_ForAdmins()
        {
            var request = new CreateServiceRequest
            {
                Name = "Test",
                Description = "Test",
                Price = 100
            };

            var mapped = _mapper.Map<Service>(request, opts =>
            {
                opts.Items["IsAdmin"] = true;
            });

            Assert.Equal(mapped.Name, request.Name);
            Assert.Equal(mapped.Description, request.Description);
            Assert.Equal(mapped.Price, request.Price);
        }
    }
}
