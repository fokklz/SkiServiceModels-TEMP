using AutoMapper;
using MongoDB.Bson;
using SkiServiceModels.BSON.AutoMapper;
using SkiServiceModels.BSON.DTOs.Request;
using SkiServiceModels.BSON.Models;
using System.Diagnostics;
namespace SkiServiceModels.Tests
{
    public class UnitTest1
    {

        [Fact]
        public void Test1()
        {
            var config = new MapperConfiguration(cfg =>
            {
                // Assuming 'MyApplicationProfile' is your AutoMapper profile class
                cfg.AddProfile(new MappingProfile());
            });

            var mapper = config.CreateMapper();

            var update = new UpdateOrderRequest
            {
                Name = "Test",
                PriorityId = ObjectId.GenerateNewId().ToString(),
                StateId = ObjectId.GenerateNewId().ToString(),
                ServiceId = ObjectId.GenerateNewId().ToString(),
                UserId = ObjectId.GenerateNewId().ToString()
            };

            var mapped = mapper.Map<Order>(update);

            Debug.Write(mapped);
        }
    }
}