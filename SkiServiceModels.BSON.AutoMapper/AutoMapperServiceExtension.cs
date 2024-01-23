using Microsoft.Extensions.DependencyInjection;

namespace SkiServiceModels.BSON.AutoMapper
{
    public static class AutoMapperServiceExtension
    {
        public static IServiceCollection AddAutoMapperProfile(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(MappingProfile).Assembly);
            return services;
        }
    }
}
