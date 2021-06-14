using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Domain.Core.Models.Booking;

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
            context.LeisureServiceCategories.AddRange(new LeisureServiceCategory
            {
                Name = "Sport"
            }, new LeisureServiceCategory
            {
                Name = "Food"
            }, new LeisureServiceCategory
            {
                Name = "Cinema"
            }, new LeisureServiceCategory
            {
                Name = "Bar"
            }, new LeisureServiceCategory
            {
                Name = "Club"
            }, new LeisureServiceCategory
            {
                Name = "Spa"
            });
            context.SaveChanges();
            return host;
        }
    }
}
