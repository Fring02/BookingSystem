using System;
using Xunit;
using Domain.Interfaces.Repositories.Booking;
using Infrastructure.Repositories.Booking;
using Moq;
using Infrastructure.Data;
using System.Threading.Tasks;
using System.Collections.Generic;
using Domain.Models.Booking;
using Microsoft.EntityFrameworkCore;

namespace Booking.Infrastructure.Tests
{
    public class LeisureServiceCategoriesRepositoryTest
    {
        private ILeisureServicesCategoriesRepository _repository;
        private string _connectionString = "Server=localhost; Port=5432; Database=booking; User Id=postgres; Password=Rubin1!!";
        private DbContextOptionsBuilder<BookingContext> _optionsBuilder = new DbContextOptionsBuilder<BookingContext>();
        [Fact]
        public async Task GetAllCategories_Returns_NotNull()
        {
            //Arrange
            using(var context = new BookingContext(_optionsBuilder.UseNpgsql(_connectionString).Options))
            {
                _repository = new LeisureServicesCategoriesRepository(context);
                //Act
                var categories = await _repository.GetAllAsync();
            //Assert
            Assert.NotNull(categories);
            }
        }

        [Theory]
        [InlineData("4281aac4-f49e-4f8f-b55f-8c2447c4e9b6")]
        public async Task GetCategoryById_Returns_NotNull(string idStr)
        {
            //Arrange
            using (var context = new BookingContext(_optionsBuilder.UseNpgsql(_connectionString).Options))
            {
                _repository = new LeisureServicesCategoriesRepository(context);
                //Act
                var category = await _repository.GetByIdAsync(Guid.Parse(idStr));

                //Assert
                Assert.NotNull(category);

                Assert.Equal("Food", category.Name);
            }
        }
    }
}
