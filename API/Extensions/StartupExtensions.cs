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
            services.AddScoped<ILeisureServicesRepository, LeisureServicesRepository>();
            services.AddScoped<IServiceImageRepository, ServiceImagesRepository>();
            services.AddScoped<IBookingRequestsRepository, BookingRequestsRepository>();
            services.AddScoped<ILeisureServicesCategoriesRepository, LeisureServicesCategoriesRepository>();
            return services;
        }

        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<ILeisureServicesService, LeisureServicesService>();
            services.AddScoped<IBookingRequestsService, BookingRequestsService>();
            services.AddScoped<IServiceImagesService, ServiceImagesService>();
            services.AddScoped<ILeisureServicesCategoriesService, LeisureServicesCategoriesService>();
            return services;
        }
    }
}