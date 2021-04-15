using Domain.Interfaces.Repositories.Booking;
using Domain.Models.Booking;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories.Booking
{
    public class LeisureServiceCategoryRepository : BaseRepository<LeisureServiceCategory>, ILeisureServicesCategoriesRepository
    {
        public LeisureServiceCategoryRepository(BookingContext context) : base(context)
        {
        }
        public override async Task<IEnumerable<LeisureServiceCategory>> GetAllAsync()
        {
            return await _context.LeisureServiceCategories.Include(c => c.Services).ToListAsync();
        }
        public override async Task<LeisureServiceCategory> GetByIdAsync(Guid id)
        {
            return await _context.LeisureServiceCategories.Include(c => c.Services).FirstOrDefaultAsync(c => c.Id == id);
        }
        public async Task<LeisureServiceCategory> GetByName(string categoryName)
        {
            return await _context.LeisureServiceCategories.FirstOrDefaultAsync(c => c.Name == categoryName);
        }
    }
}
