using Microsoft.Extensions.DependencyInjection;
using UcakBiletim.Business.Services.Flights;
using UcakBiletim.Business.Services.Users;

namespace UcakBiletim.Business
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddBusiness(this IServiceCollection services)
        {
            services.ConfigureServices();
            return services;
        }

        private static IServiceCollection ConfigureServices(this IServiceCollection services)
        {
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IFlightService, FlightService>();

            return services;
        }
    }
}
