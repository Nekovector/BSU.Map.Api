using AutoMapper;
using BSU.Map.BLL.Interfaces;
using BSU.Map.BLL.Mappers;
using BSU.Map.BLL.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BSU.Map.BLL.DI
{
    public static class DependencyRegistrator
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IBuildingService, BuildingService>();
            services.AddScoped<IStructuralObjectService, StructuralObjectService>();
            services.AddScoped<IPhotoService, PhotoService>();
            services.AddScoped<IMemoryPhotoService, MemoryPhotoService>();
            services.AddScoped<IScientistService, ScientistService>();

            return services;
        }

        public static IServiceCollection RegisterBllAutoMapper(this IServiceCollection services, IConfiguration configuration)
        {
            // Auto Mapper Configurations
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfiles());
            });

            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);

            return services;
        }
    }
}
