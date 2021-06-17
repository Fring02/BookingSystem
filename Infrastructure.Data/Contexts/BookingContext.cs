using System;
using Domain.Core.Helpers;
using Domain.Core.Models.Booking;
using Domain.Core.Models.Users;
using Domain.Models.Users;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Contexts
{
    public class BookingContext : DbContext
    {
        public BookingContext(DbContextOptions<BookingContext> options) : base(options)
        {
        }

        /*
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

        */
        public DbSet<LeisureService> LeisureServices { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ServiceImage> ServicesImages { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Owner> Owners { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Comment> Comments { get; set; }
    }
}