using BSU.Map.DAL.Interfaces;
using BSU.Map.DAL.Models;
using BSU.Map.DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BSU.Map.DAL.DI
{
    public static class DependencyRegistrator
    {
        private const string connectionStringName = "BsuMapDbConnection";

        public static IServiceCollection AddDataAccessDatabaseComponents(this IServiceCollection services, IConfiguration configuration)
        {
            AddDbContext(services, configuration);

            //AddRepositories(services);

            AddUnitOfWork(services);

            return services;
        }

        private static void AddDbContext(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseNpgsql(configuration.GetConnectionString(connectionStringName)));
        }

        private static void AddRepositories(IServiceCollection services)
        {
            services.AddTransient<IRepository<Building>, Repository<Building>>();
            services.AddTransient<IRepository<StructuralObject>, Repository<StructuralObject>>();
            services.AddTransient<IRepository<Photo>, Repository<Photo>>();
        }

        private static void AddUnitOfWork(IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}
