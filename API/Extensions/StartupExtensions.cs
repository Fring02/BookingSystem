using Domain.Interfaces.Repositories.Booking;
using Domain.Interfaces.Repositories.Users;
using Domain.Interfaces.Services.Booking;
using Domain.Interfaces.Services.Users;
using Infrastructure.Repositories.Booking;
using Infrastructure.Repositories.Users;
using Domain.Interfaces.Services;
using Domain.Interfaces.Services.Booking;
using Infrastructure.Repositories;
using Infrastructure.Repositories.Booking;
using Infrastructure.Services;
using Infrastructure.Services.Booking;
using Infrastructure.Services.Users;
using Microsoft.Extensions.DependencyInjection;
using Infrastructure.Helpers;

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
            services.AddScoped<IOwnersRepository, OwnersRepository>();
            services.AddScoped<IUsersRepository, UsersRepository>();
            return services;
        }

        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<ILeisureServicesService, LeisureServicesService>();
            services.AddScoped<IBookingRequestsService, BookingRequestsService>();
            services.AddScoped<IServiceImagesService, ServiceImagesService>();
            services.AddScoped<ILeisureServicesCategoriesService, LeisureServicesCategoriesService>();
            services.AddScoped<IOwnersService, OwnersService>();
            services.AddScoped<IUserService, UsersService>();
            services.AddSingleton<IPasswordEncryptor, SHA512PasswordEncryptor>();
            services.AddSingleton<Notifier>();
            return services;
        }

    }
}