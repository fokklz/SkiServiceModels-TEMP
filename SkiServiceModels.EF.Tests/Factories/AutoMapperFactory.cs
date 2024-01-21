using SkiServiceModels.EF.AutoMapper;

namespace SkiServiceModels.EF.Tests.Factories
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
