using Microsoft.Extensions.DependencyInjection;

namespace SkiServiceModels.EF.AutoMapper
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
