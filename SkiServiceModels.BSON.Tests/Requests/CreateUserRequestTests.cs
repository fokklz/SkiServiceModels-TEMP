using MongoDB.Bson;
using SkiServiceModels.BSON.DTOs.Requests;
using SkiServiceModels.BSON.Models;
using SkiServiceModels.Enums;

namespace SkiUserModels.BSON.Tests.Requests
{
    public class CreateUserRequestTests
    {
        private readonly IMapper _mapper = AutoMapperFactory.Create();

        [Fact]
        public void ParseToUser_IgnoresIdAndIsDeleted_ForNoneAdmins()
        {
            var requestJson = @"{
                ""id"": ""5f9d7a9d9d9d9d9d9d9d9d9"",
                ""is_deleted"": true,
                ""username"": ""Test""
            }";

            var parsed = JsonConvert.DeserializeObject<CreateUserRequest>(requestJson);
            var response = _mapper.Map<User>(parsed);

            Assert.Equal(response.Id, ObjectId.Empty);
            Assert.False(response.IsDeleted);
        }

        [Fact]
        public void ParseToUser_IgnoresIdAndIsDeleted_ForAdmins()
        {
            var requestJson = @"{
                ""id"": ""5f9d7a9d9d9d9d9d9d9d9d9"",
                ""is_deleted"": true,
                ""username"": ""Test""
            }";

            var parsed = JsonConvert.DeserializeObject<CreateUserRequest>(requestJson);
            var response = _mapper.Map<User>(parsed, opts =>
            {
                opts.Items["IsAdmin"] = true;
            });

            Assert.Equal(response.Id, ObjectId.Empty);
            Assert.False(response.IsDeleted);
        }

        [Fact]
        public void MapToUser_IncludeAllProperties_ForNoneAdmins()
        {
            var request = new CreateUserRequest
            {
                Username = "Test",
                Role = RoleNames.SuperAdmin,
                Password = "Test"
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
                Role = RoleNames.SuperAdmin,
                Password = "Test"
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
