using AutoMapper;
using MongoDB.Bson;
using Newtonsoft.Json;
using SkiServiceModels.BSON.AutoMapper;
using SkiServiceModels.BSON.DTOs.Response;
using SkiServiceModels.BSON.Models;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var config = new MapperConfiguration(cfg =>
            {
                // Assuming 'MyApplicationProfile' is your AutoMapper profile class
                cfg.AddProfile(new MappingProfile());
            });

            var mapper = config.CreateMapper();

            var userId = ObjectId.GenerateNewId();
            var exsitingOrder = new Order
            {
                Id = ObjectId.GenerateNewId(),
                Name = "Test",
                PriorityId = ObjectId.GenerateNewId(),
                StateId = ObjectId.GenerateNewId(),
                ServiceId = ObjectId.GenerateNewId(),
                UserId = userId,
                Email = "Hallo@gmail.com",
                Phone = "123456789"
            };

            var mapped = mapper.Map<OrderResponse>(exsitingOrder);

            foreach (var prop in mapped.GetType().GetProperties())
            {
                Console.WriteLine($"{prop.Name}: {prop.GetValue(mapped)}");
            }

            var json = JsonConvert.SerializeObject(mapped);
            Console.WriteLine(json);
        }
    }
}
