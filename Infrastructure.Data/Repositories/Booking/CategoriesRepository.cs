using System;
using System.Threading.Tasks;
using Domain.Core.Models.Booking;
using Domain.Interfaces.Repositories.Booking;
using Infrastructure.Data.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Repositories.Booking
{
    public class CategoriesRepository : BaseRepository<Category, Guid>, ICategoriesRepository
    {
        public CategoriesRepository(BookingContext context) : base(context)
        {
        }
        public override async Task<Category> GetByIdAsync(Guid id)
        {
            return await _context.Categories.AsNoTracking().Include(c => c.Services).FirstOrDefaultAsync(c => c.Id == id).ConfigureAwait(false);
        }
        public async Task<Category> GetByNameAsync(string categoryName)
        {
            return await _context.Categories.FirstOrDefaultAsync(c => c.Name == categoryName).ConfigureAwait(false);
        }
    }
}
