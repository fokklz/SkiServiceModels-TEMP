using SkiServiceModels.EF.DTOs.Requests;
using SkiServiceModels.EF.Models;

namespace SkiServiceModels.EF.Tests.Requests
{
    public class CreatePriorityRequestTests
    {
        private readonly IMapper _mapper = AutoMapperFactory.Create();

        [Fact]
        public void ParseToPriority_IgnoresIdAndIsDeleted_ForNoneAdmins()
        {
            var requestJson = @"{
                ""id"": 1,
                ""is_deleted"": true,
                ""name"": ""Test"",
                ""days"": 10
            }";

            var parsed = JsonConvert.DeserializeObject<CreatePriorityRequest>(requestJson);
            var response = _mapper.Map<Priority>(parsed);

            Assert.NotEqual(1, response.Id);
            Assert.False(response.IsDeleted);
        }

        [Fact]
        public void ParseToPriority_IgnoresIdAndIsDeleted_ForAdmins()
        {
            var requestJson = @"{
                ""id"": 1,
                ""is_deleted"": true,
                ""name"": ""Test"",
                ""days"": 10
            }";

            var parsed = JsonConvert.DeserializeObject<CreatePriorityRequest>(requestJson);
            var response = _mapper.Map<Priority>(parsed, opts =>
            {
                opts.Items["IsAdmin"] = true;
            });

            Assert.NotEqual(1, response.Id);
            Assert.False(response.IsDeleted);
        }

        [Fact]
        public void MapToPriority_IncludeAllProperties_ForNoneAdmins()
        {
            var request = new CreatePriorityRequest
            {
                Name = "Test",
                Days = 10
            };

            var mapped = _mapper.Map<Priority>(request);

            Assert.Equal(mapped.Name, request.Name);
            Assert.Equal(mapped.Days, request.Days);
        }

        [Fact]
        public void MapToPriority_IncludeAllProperties_ForAdmins()
        {
            var request = new CreatePriorityRequest
            {
                Name = "Test",
                Days = 10
            };

            var mapped = _mapper.Map<Priority>(request, opts =>
            {
                opts.Items["IsAdmin"] = true;
            });

            Assert.Equal(mapped.Name, request.Name);
            Assert.Equal(mapped.Days, request.Days);
        }
    }
}
