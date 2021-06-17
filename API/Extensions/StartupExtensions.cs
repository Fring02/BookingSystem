using Domain.Interfaces.Repositories.Booking;
using Domain.Interfaces.Repositories.Users;
using Domain.Interfaces.Services.Booking;
using Domain.Interfaces.Services.Users;
using Infrastructure.Data.Repositories.Booking;
using Infrastructure.Data.Repositories.Users;
using Infrastructure.Services;
using Infrastructure.Services.Booking;
using Infrastructure.Services.Users;
using Infrastructure.Services.Utils;
using Microsoft.Extensions.DependencyInjection;

namespace Booking.API.Extensions
{
    public static class StartupExtensions
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<ILeisureServicesRepository, LeisureServicesRepository>();
            services.AddScoped<IServiceImageRepository, ServiceImagesRepository>();
            services.AddScoped<IOrdersRepository, OrdersRepository>();
            services.AddScoped<ICategoriesRepository, CategoriesRepository>();
            services.AddScoped<IOwnersRepository, OwnersRepository>();
            services.AddScoped<IUsersRepository, UsersRepository>();
            services.AddScoped<ICommentRepository, CommentRepository>();
            return services;
        }

        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<ILeisureServicesService, LeisureServicesService>();
            services.AddScoped<IOrdersService, OrdersService>();
            services.AddScoped<IServiceImagesService, ServiceImagesService>();
            services.AddScoped<ICategoriesService, CategoriesService>();
            services.AddScoped<IOwnersService, OwnersService>();
            services.AddScoped<IUserService, UsersService>();
            services.AddScoped<ICommentService, CommentService>();
            services.AddSingleton<IPasswordEncryptor, SHA512PasswordEncryptor>();
            services.AddSingleton<Notifier>();
            return services;
        }

    }
}