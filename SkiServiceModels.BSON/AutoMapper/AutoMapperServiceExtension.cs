using Microsoft.Extensions.DependencyInjection;

namespace SkiServiceModels.BSON.AutoMapper
{
    public static class AutoMapperServiceExtension
    {
        public static IServiceCollection AddAutoMapperProfiles(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(MappingProfile).Assembly);
            return services;
        }
    }
}
