using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using UcakBiletim.DataAccess.Contexts;
using UcakBiletim.DataAccess.Repositories;
using UcakBiletim.DataAccess.Repositories.Flights;
using UcakBiletim.DataAccess.Repositories.Users;

namespace UcakBiletim.DataAccess
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDataAccess(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddRepositories();
            services.ConfigureDatabase(configuration);
            return services;
        }

        private static IServiceCollection ConfigureDatabase(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<UcakBiletimContext>(
                options =>
                {
                    options.UseSqlServer(configuration.GetConnectionString("DefaultSQL"));
                });
            return services;
        }

        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IFlightRepository, FlightRepository>();

            return services;
        }
    }
}
