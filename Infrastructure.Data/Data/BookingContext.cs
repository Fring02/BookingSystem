using Domain.Core.Helpers;
using Domain.Core.Models.Booking;
using Microsoft.EntityFrameworkCore;
using System;

namespace Infrastructure.Data
{
    public class BookingContext : DbContext
    {
        public BookingContext(DbContextOptions<BookingContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Owner>().HasData(new Owner
            {
                Id = Guid.NewGuid(),
                Email = "hasenovsultanbek@gmail.com",
                Firstname = "Sultanbek",
                Lastname = "Hasenov",
                MobilePhone = "+7(776)-166-70-60",
                Password = "qwerty123",
                Role = Roles.ADMIN
            });
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<LeisureService> LeisureServices { get; set; }
        public DbSet<LeisureServiceCategory> LeisureServiceCategories { get; set; }
        public DbSet<ServiceImage> ServicesImages { get; set; }
        public DbSet<BookingRequest> BookingRequests { get; set; }
        public DbSet<Owner> LeisureServicesOwners { get; set; }
        public DbSet<User> Users { get; set; }
    }
}