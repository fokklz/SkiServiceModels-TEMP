using MongoDB.Bson;
using SkiServiceModels.BSON.DTOs.Requests;
using SkiServiceModels.BSON.Interfaces;
using SkiServiceModels.BSON.Models;

namespace SkiOrderModels.BSON.Tests.Requests
{
    public class CreateOrderRequestTests
    {
        private readonly IMapper _mapper = AutoMapperFactory.Create();

        [Fact]
        public void ParseToOrder_IgnoresIdAndIsDeleted_ForNoneAdmins()
        {
            var requestJson = @"{
                ""id"": ""5f9d7a9d9d9d9d9d9d9d9d9"",
                ""is_deleted"": true,
                ""email"": ""Test"",
                ""name"": ""Test"",
                ""phone"": ""Test"",
                ""note"": ""Test"",
                ""priority_id"": ""5f9d7a9d9d9d9d9d9d9d9d9"",
                ""service_id"": ""5f9d7a9d9d9d9d9d9d9d9d9"",
                ""state_id"": ""5f9d7a9d9d9d9d9d9d9d9d9"",
                ""user_id"": ""5f9d7a9d9d9d9d9d9d9d9d9"",
            }";

            var parsed = JsonConvert.DeserializeObject<CreateOrderRequest>(requestJson);
            var response = _mapper.Map<Order>(parsed);

            Assert.Equal(response.Id, ObjectId.Empty);
            Assert.False(response.IsDeleted);
        }

        [Fact]
        public void ParseToOrder_IgnoresIdAndIsDeleted_ForAdmins()
        {
            var requestJson = @"{
                ""id"": ""5f9d7a9d9d9d9d9d9d9d9d9"",
                ""is_deleted"": true,
                ""email"": ""Test"",
                ""name"": ""Test"",
                ""phone"": ""Test"",
                ""note"": ""Test"",
                ""priority_id"": ""5f9d7a9d9d9d9d9d9d9d9d9"",
                ""service_id"": ""5f9d7a9d9d9d9d9d9d9d9d9"",
                ""state_id"": ""5f9d7a9d9d9d9d9d9d9d9d9"",
                ""user_id"": ""5f9d7a9d9d9d9d9d9d9d9d9"",
            }";

            var parsed = JsonConvert.DeserializeObject<CreateOrderRequest>(requestJson);
            var response = _mapper.Map<Order>(parsed, opts =>
            {
                opts.Items["IsAdmin"] = true;
            });

            Assert.Equal(response.Id, ObjectId.Empty);
            Assert.False(response.IsDeleted);
        }

        [Fact]
        public void MapToOrder_IncludeAllProperties_ForNoneAdmins()
        {
            var request = new CreateOrderRequest
            {
                Email = "Test",
                Name = "Test",
                Phone = "Test",
                Note = "Test",
                PriorityId = ObjectId.GenerateNewId().ToString(),
                ServiceId = ObjectId.GenerateNewId().ToString(),
                StateId = ObjectId.GenerateNewId().ToString(),
                UserId = ObjectId.GenerateNewId().ToString(),
            };

            var mapped = _mapper.Map<Order>(request);

            Assert.Equal(mapped.Email, request.Email);
            Assert.Equal(mapped.Name, request.Name);
            Assert.Equal(mapped.Phone, request.Phone);
            Assert.Equal(mapped.Note, request.Note);
            Assert.Equal(mapped.PriorityId, (request as IOrder).PriorityId);
            Assert.Equal(mapped.StateId, (request as IOrder).StateId);
            Assert.Equal(mapped.ServiceId, (request as IOrder).ServiceId);
            Assert.Equal(mapped.UserId, (request as IOrder).UserId);
        }

        [Fact]
        public void MapToOrder_IncludeAllProperties_ForAdmins()
        {
            var request = new CreateOrderRequest
            {
                Email = "Test",
                Name = "Test",
                Phone = "Test",
                Note = "Test",
                PriorityId = ObjectId.GenerateNewId().ToString(),
                ServiceId = ObjectId.GenerateNewId().ToString(),
                StateId = ObjectId.GenerateNewId().ToString(),
                UserId = ObjectId.GenerateNewId().ToString(),
            };

            var mapped = _mapper.Map<Order>(request, opts =>
            {
                opts.Items["IsAdmin"] = true;
            });


            Assert.Equal(mapped.Email, request.Email);
            Assert.Equal(mapped.Name, request.Name);
            Assert.Equal(mapped.Phone, request.Phone);
            Assert.Equal(mapped.Note, request.Note);
            Assert.Equal(mapped.PriorityId, (request as IOrder).PriorityId);
            Assert.Equal(mapped.StateId, (request as IOrder).StateId);
            Assert.Equal(mapped.ServiceId, (request as IOrder).ServiceId);
            Assert.Equal(mapped.UserId, (request as IOrder).UserId);
        }
    }
}
