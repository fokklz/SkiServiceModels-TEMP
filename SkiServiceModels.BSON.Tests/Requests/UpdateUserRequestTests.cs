
using MongoDB.Bson;
using SkiServiceModels.BSON.DTOs.Request;
using SkiServiceModels.BSON.Models;
using SkiServiceModels.Enums;

namespace SkiServiceModels.BSON.Tests.Requests
{
    public class UpdateUserRequestTests
    {
        private readonly IMapper _mapper = AutoMapperFactory.Create();

        [Fact]
        public void ParseToUser_IgnoresIdAndIsDeleted_ForNoneAdmins()
        {
            var requestJson = @"{
                ""id"": ""5f9d7a9d9d9d9d9d9d9d9d9"",
                ""is_deleted"": true,
                ""username"": ""Test"",
                ""locked"": true,
                ""role"": ""SuperAdmin""
            }";

            var parsed = JsonConvert.DeserializeObject<UpdateUserRequest>(requestJson);
            var response = _mapper.Map<User>(parsed);

            Assert.Equal(response.Id, ObjectId.Empty);
            Assert.False(response.IsDeleted);
        }

        [Fact]
        public void ParseToUser_IgnoresIdAndIncludesIsDeleted_ForAdmins()
        {
            var requestJson = @"{
                ""id"": ""5f9d7a9d9d9d9d9d9d9d9d9"",
                ""is_deleted"": true,
                ""username"": ""Test"",
                ""locked"": true,
                ""role"": ""SuperAdmin""
            }";

            var parsed = JsonConvert.DeserializeObject<UpdateUserRequest>(requestJson);
            var response = _mapper.Map<User>(parsed, opts =>
            {
                opts.Items["IsAdmin"] = true;
            });

            Assert.Equal(response.Id, ObjectId.Empty);
            Assert.True(response.IsDeleted);
        }

        [Fact]
        public void MapToUser_IncludeAllProperties_ForNoneAdmins()
        {
            var request = new UpdateUserRequest
            {
                IsDeleted = true,
                Username = "Test",
                Locked = true,
                Role = RoleNames.SuperAdmin,
            };

            var mapped = _mapper.Map<User>(request);

            Assert.Equal(mapped.Username, request.Username);
            Assert.NotEqual(mapped.IsDeleted, request.IsDeleted);
            Assert.NotEqual(mapped.Locked, request.Locked);
            Assert.NotEqual(mapped.Role, request.Role);
        }

        [Fact]
        public void MapToUser_IncludeAllProperties_ForAdmins()
        {
            var request = new UpdateUserRequest
            {
                IsDeleted = true,
                Username = "Test",
                Locked = true,
                Role = RoleNames.SuperAdmin,
            };

            var mapped = _mapper.Map<User>(request, opts =>
            {
                opts.Items["IsAdmin"] = true;
            });

            Assert.Equal(mapped.Username, request.Username);
            Assert.Equal(mapped.IsDeleted, request.IsDeleted);
            Assert.Equal(mapped.Locked, request.Locked);
            Assert.Equal(mapped.Role, request.Role);
        }
    }
}
