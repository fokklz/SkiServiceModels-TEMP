using SkiServiceModels.EF.DTOs.Requests;
using SkiServiceModels.EF.Models;
using SkiServiceModels.Enums;

namespace SkiServiceModels.EF.Tests.Requests
{
    public class CreateUserRequestTests
    {
        private readonly IMapper _mapper = AutoMapperFactory.Create();

        [Fact]
        public void ParseToUser_IgnoresIdAndIsDeleted_ForNoneAdmins()
        {
            var requestJson = @"{
                ""id"": 1,
                ""is_deleted"": true,
                ""username"": ""Test""
            }";

            var parsed = JsonConvert.DeserializeObject<CreateUserRequest>(requestJson);
            var response = _mapper.Map<User>(parsed);

            Assert.NotEqual(1, response.Id);
            Assert.False(response.IsDeleted);
        }

        [Fact]
        public void ParseToUser_IgnoresIdAndIsDeleted_ForAdmins()
        {
            var requestJson = @"{
                ""id"": 1,
                ""is_deleted"": true,
                ""username"": ""Test""
            }";

            var parsed = JsonConvert.DeserializeObject<CreateUserRequest>(requestJson);
            var response = _mapper.Map<User>(parsed, opts =>
            {
                opts.Items["IsAdmin"] = true;
            });

            Assert.NotEqual(1, response.Id);
            Assert.False(response.IsDeleted);
        }

        [Fact]
        public void MapToUser_IncludeAllProperties_ForNoneAdmins()
        {
            var request = new CreateUserRequest
            {
                Username = "Test",
                Role = RoleNames.SuperAdmin
            };

            var mapped = _mapper.Map<User>(request);

            Assert.Equal(mapped.Username, request.Username);
            Assert.NotEqual(mapped.Role, request.Role);
        }

        [Fact]
        public void MapToUser_IncludeAllProperties_ForAdmins()
        {
            var request = new CreateUserRequest
            {
                Username = "Test",
                Role = RoleNames.SuperAdmin
            };

            var mapped = _mapper.Map<User>(request, opts =>
            {
                opts.Items["IsAdmin"] = true;
            });

            Assert.Equal(mapped.Username, request.Username);
            Assert.Equal(mapped.Role, request.Role);
        }
    }
}
