using Domain.Interfaces.Repositories.Booking;
using Domain.Interfaces.Repositories.Users;
<<<<<<< HEAD
using Domain.Interfaces.Services.Booking;
using Domain.Interfaces.Services.Users;
using Infrastructure.Repositories.Booking;
using Infrastructure.Repositories.Users;
=======
using Domain.Interfaces.Services;
using Domain.Interfaces.Services.Booking;
using Infrastructure.Repositories;
using Infrastructure.Repositories.Booking;
using Infrastructure.Services;
>>>>>>> f3337821cdfc417096ac2cc0c77929f7fb77bbb4
using Infrastructure.Services.Booking;
using Infrastructure.Services.Users;
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
<<<<<<< HEAD
            services.AddScoped<IOwnersRepository, OwnersRepository>();
=======
            services.AddScoped<IUserRepository, UserRepository>();
>>>>>>> f3337821cdfc417096ac2cc0c77929f7fb77bbb4
            return services;
        }

        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<ILeisureServicesService, LeisureServicesService>();
            services.AddScoped<IBookingRequestsService, BookingRequestsService>();
            services.AddScoped<IServiceImagesService, ServiceImagesService>();
            services.AddScoped<ILeisureServicesCategoriesService, LeisureServicesCategoriesService>();
<<<<<<< HEAD
            services.AddScoped<IOwnersService, OwnersService>();
=======
            services.AddScoped<IUserService, UserService>();
>>>>>>> f3337821cdfc417096ac2cc0c77929f7fb77bbb4
            return services;
        }
    }
}