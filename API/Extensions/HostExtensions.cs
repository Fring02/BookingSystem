using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Domain.Core.Models.Booking;
using Infrastructure.Data.Contexts;

namespace Booking.API.Extensions
{
    public static class HostExtensions
    {

        public static IHost ApplyDatabaseMigrations(this IHost host)
        {
            using var scope = host.Services.CreateScope();
            using var context = scope.ServiceProvider.GetRequiredService<BookingContext>();
            context.Database.Migrate();
            return host;
        }

        public static IHost SeedData(this IHost host)
        {
            using var scope = host.Services.CreateScope();
            using var context = scope.ServiceProvider.GetRequiredService<BookingContext>();
            context.Categories.AddRange(new Category
            {
                Name = "Sport"
            }, new Category
            {
                Name = "Food"
            }, new Category
            {
                Name = "Cinema"
            }, new Category
            {
                Name = "Bar"
            }, new Category
            {
                Name = "Club"
            }, new Category
            {
                Name = "Spa"
            });
            context.SaveChanges();
            return host;
        }
    }
}
