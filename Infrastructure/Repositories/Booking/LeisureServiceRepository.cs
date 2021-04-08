using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Interfaces.Repositories.Booking;
using Domain.Models.Booking;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.Booking
{
    public class LeisureServiceRepository : BaseRepository<LeisureService>,ILeisureServiceRepository
    {
        public LeisureServiceRepository(BookingContext context) : base(context)
        {
        }

        public async Task<IEnumerable<LeisureService>> GetByRating(int rating)
        {
            return await _context.LeisureServices.Where(s => s.Rating == rating).ToListAsync();
        }

        public async Task<IEnumerable<LeisureService>> GetByWorkingTime(string workingTime)
        {
            return await _context.LeisureServices.Where(s => s.WorkingTime == workingTime).ToListAsync();
        }
    }
}