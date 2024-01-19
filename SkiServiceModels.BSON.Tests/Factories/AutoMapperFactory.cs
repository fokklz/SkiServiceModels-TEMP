using AutoMapper;
using SkiServiceModels.BSON.AutoMapper;

namespace SkiServiceModels.BSON.Tests.Factories
{
    public static class AutoMapperFactory
    {
        public static IMapper Create()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });
            return config.CreateMapper();
        }
    }
}
