
using MongoDB.Bson;
using SkiServiceModels.BSON.DTOs.Requests;
using SkiServiceModels.BSON.Models;

namespace SkiServiceModels.BSON.Tests.Requests
{
    public class UpdatePriorityRequestTests
    {
        private readonly IMapper _mapper = AutoMapperFactory.Create();

        [Fact]
        public void ParseToPriority_IgnoresIdAndIsDeleted_ForNoneAdmins()
        {
            var requestJson = @"{
                ""id"": ""5f9d7a9d9d9d9d9d9d9d9d9"",
                ""is_deleted"": true,
                ""name"": ""Test"",
                ""days"": 10
            }";

            var parsed = JsonConvert.DeserializeObject<UpdatePriorityRequest>(requestJson);
            var response = _mapper.Map<Priority>(parsed);

            Assert.Equal(response.Id, ObjectId.Empty);
            Assert.False(response.IsDeleted);
        }

        [Fact]
        public void ParseToPriority_IgnoresIdAndIncludesIsDeleted_ForAdmins()
        {
            var requestJson = @"{
                ""id"": ""5f9d7a9d9d9d9d9d9d9d9d9"",
                ""is_deleted"": true,
                ""name"": ""Test"",
                ""days"": 10
            }";

            var parsed = JsonConvert.DeserializeObject<UpdatePriorityRequest>(requestJson);
            var response = _mapper.Map<Priority>(parsed, opts =>
            {
                opts.Items["IsAdmin"] = true;
            });

            Assert.Equal(response.Id, ObjectId.Empty);
            Assert.True(response.IsDeleted);
        }

        [Fact]
        public void MapToPriority_IncludeAllProperties_ForNoneAdmins()
        {
            var request = new UpdatePriorityRequest
            {
                IsDeleted = true,
                Name = "Test",
                Days = 10
            };

            var mapped = _mapper.Map<Priority>(request);

            Assert.Equal(mapped.Name, request.Name);
            Assert.NotEqual(mapped.IsDeleted, request.IsDeleted);
            Assert.Equal(mapped.Days, request.Days);
        }

        [Fact]
        public void MapToPriority_IncludeAllProperties_ForAdmins()
        {
            var request = new UpdatePriorityRequest
            {
                IsDeleted = true,
                Name = "Test",
                Days = 10
            };

            var mapped = _mapper.Map<Priority>(request, opts =>
            {
                opts.Items["IsAdmin"] = true;
            });

            Assert.Equal(mapped.Name, request.Name);
            Assert.Equal(mapped.IsDeleted, request.IsDeleted);
            Assert.Equal(mapped.Days, request.Days);
        }
    }
}
