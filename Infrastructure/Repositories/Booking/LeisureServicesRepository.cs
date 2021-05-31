using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Interfaces.Repositories.Booking;
using Domain.Models.Booking;
using Infrastructure.Data;
using Infrastructure.Helpers;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.Booking
{
    public class LeisureServicesRepository : BaseRepository<LeisureService>,ILeisureServicesRepository
    {
        private FilterBuilder _builder;
        public LeisureServicesRepository(BookingContext context) : base(context)
        {
        }
        public override async Task<LeisureService> GetByIdAsync(Guid id)
        {
            return await _context.LeisureServices.AsNoTracking().Include(s => s.Category).Include(s => s.Images).FirstOrDefaultAsync(s => s.Id == id).ConfigureAwait(false);
        }
        public override async Task<IEnumerable<LeisureService>> GetAllAsync()
        {
            return await _context.LeisureServices.AsNoTracking().Include(s => s.Category).Include(s => s.Images).ToListAsync().ConfigureAwait(false);
        }

        public async Task<IEnumerable<LeisureService>> GetByRatingAsync(int rating)
        {
            return await _context.LeisureServices.AsNoTracking().Include(s => s.Images).Include(s => s.Category).
                Where(s => Math.Round(s.Rating) == rating).ToListAsync().ConfigureAwait(false);
        }

        public async Task<IEnumerable<LeisureService>> GetByWorkingTimeAsync(string workingTime)
        {
            return await _context.LeisureServices.AsNoTracking().Include(s => s.Images).Include(s => s.Category).
                Where(s => s.WorkingTime == workingTime).ToListAsync().ConfigureAwait(false);
        }

        public async Task<IEnumerable<LeisureService>> GetByCategoryIdAsync(Guid categoryId)
        {
            return await _context.LeisureServices.AsNoTracking().Where(s => s.CategoryId == categoryId).Include(s => s.Images).Include(s => s.Category).ToListAsync().ConfigureAwait(false);
        }

        public async Task<IEnumerable<LeisureService>> GetByFilterAsync(Guid categoryId = default, string workingTime = null, int rating = 0)
        {
            _builder = new FilterBuilder(_context.LeisureServices);
            var filteredServices = _builder.WithCategory(categoryId).WithRating(rating).WithWorkingTime(workingTime).Build();
            return await filteredServices.AsNoTracking().Include(s => s.Images).Include(s => s.Category).ToListAsync().ConfigureAwait(false);
        }

        public async Task<bool> ServiceExistsAsync(string name)
        {
            return await _context.LeisureServices.AnyAsync(s => s.Name == name).ConfigureAwait(false);
        }

        public async Task<IEnumerable<LeisureService>> GetByOwnerIdAsync(Guid ownerId)
        {
            return await _context.LeisureServices.AsNoTracking().Where(s => s.OwnerId == ownerId).Include(s => s.Images).Include(s => s.Category).ToListAsync().ConfigureAwait(false);
        }

        public async Task<IEnumerable<LeisureService>> GetByPopularityAsync(int count)
        {
            var services = _context.LeisureServices.AsNoTracking().Include(s => s.Images).
                OrderByDescending(s => s.RatedCount);
            if (count > 0) return await services.Take(count).ToListAsync().ConfigureAwait(false);
            else return await services.ToListAsync().ConfigureAwait(false);
        }

        public async Task<IEnumerable<LeisureService>> GetByNameAsync(string name)
        {
            return await _context.LeisureServices.AsNoTracking().Where(s => s.Name.Contains(name)).
                Include(s => s.Images).Include(s => s.Category).ToListAsync().ConfigureAwait(false);
        }

        public async Task<IEnumerable<LeisureService>> GetByPageAsync(int page, int count)
        {
            return await _context.LeisureServices.AsNoTracking().Skip(page * count).Take(count).
                Include(s => s.Images).Include(s => s.Category).ToListAsync().ConfigureAwait(false);
        }
    }
}