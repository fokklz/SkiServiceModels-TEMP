using SkiServiceModels.EF.DTOs.Requests;
using SkiServiceModels.EF.Interfaces;
using SkiServiceModels.EF.Models;

namespace SkiServiceModels.EF.Tests.Requests
{
    public class CreateOrderRequestTests
    {
        private readonly IMapper _mapper = AutoMapperFactory.Create();

        [Fact]
        public void ParseToOrder_IgnoresIdAndIsDeleted_ForNoneAdmins()
        {
            var requestJson = @"{
                ""id"": 1,
                ""is_deleted"": true,
                ""email"": ""Test"",
                ""name"": ""Test"",
                ""phone"": ""Test"",
                ""note"": ""Test"",
                ""priority_id"": 2,
                ""service_id"": 2,
                ""state_id"": 2,
                ""user_id"": 2,
            }";

            var parsed = JsonConvert.DeserializeObject<CreateOrderRequest>(requestJson);
            var response = _mapper.Map<Order>(parsed);

            Assert.NotEqual(1, response.Id);
            Assert.False(response.IsDeleted);
        }

        [Fact]
        public void ParseToOrder_IgnoresIdAndIsDeleted_ForAdmins()
        {
            var requestJson = @"{
                ""id"": 1,
                ""is_deleted"": true,
                ""email"": ""Test"",
                ""name"": ""Test"",
                ""phone"": ""Test"",
                ""note"": ""Test"",
                ""priority_id"": 2,
                ""service_id"": 2,
                ""state_id"": 2,
                ""user_id"": 2,
            }";

            var parsed = JsonConvert.DeserializeObject<CreateOrderRequest>(requestJson);
            var response = _mapper.Map<Order>(parsed, opts =>
            {
                opts.Items["IsAdmin"] = true;
            });

            Assert.NotEqual(1, response.Id);
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
                PriorityId = 1,
                ServiceId = 1,
                StateId = 1,
                UserId = 1,
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
                PriorityId = 1,
                ServiceId = 1,
                StateId = 1,
                UserId = 1,
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
