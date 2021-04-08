using Domain.Interfaces.Repositories.Booking;
using Domain.Interfaces.Services.Booking;
using Infrastructure.Repositories.Booking;
using Infrastructure.Services.Booking;
using Microsoft.Extensions.DependencyInjection;

namespace API.Extensions
{
    public static class StartupExtensions
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<ILeisureServiceRepository, LeisureServiceRepository>();
            return services;
        }

        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<ILeisureServicesService, LeisureServicesService>();
            return services;
        }
    }
}