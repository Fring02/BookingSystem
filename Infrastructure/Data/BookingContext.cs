using Domain.Models.Booking;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class BookingContext : DbContext
    {
        public BookingContext(DbContextOptions<BookingContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LeisureService>().HasMany<ServiceImage>().WithOne(i => i.Service);
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<LeisureService> LeisureServices { get; set; }
        public DbSet<ServiceImage> ServicesImages { get; set; }
        public DbSet<BookingRequest> BookingRequests { get; set; }
    }
}