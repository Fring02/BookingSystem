using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Core.Models.Booking;
using Domain.Interfaces.Repositories.Booking;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.Booking
{
    public class BookingRequestsRepository : BaseRepository<BookingRequest>, IBookingRequestsRepository
    {
        public BookingRequestsRepository(BookingContext context) : base(context)
        {
        }
        public override async Task<BookingRequest> GetByIdAsync(Guid id)
        {
            return await _context.BookingRequests.AsNoTracking().Include(r => r.Service).FirstOrDefaultAsync(r => r.Id == id).ConfigureAwait(false);
        }
        public override async Task<IEnumerable<BookingRequest>> GetAllAsync()
        {
            return await _context.BookingRequests.AsNoTracking().Include(r => r.Service).ToListAsync().ConfigureAwait(false);
        }
        public async Task<IEnumerable<BookingRequest>> GetByServiceIdAsync(Guid serviceId)
        {
            return await _context.BookingRequests.AsNoTracking().Include(r => r.Service).ThenInclude(s => s.Category).Where(r => r.ServiceId == serviceId).ToListAsync().ConfigureAwait(false);
        }

        public async Task<bool> HasRequestAsync(BookingRequest request)
        {
            return await _context.BookingRequests.AnyAsync(r => r.ServiceId == request.ServiceId && r.UserId == request.UserId).ConfigureAwait(false);
        }

        public async Task<IEnumerable<BookingRequest>> GetByUserIdAsync(Guid userId)
        {
            return await _context.BookingRequests.AsNoTracking().Include(r => r.Service).ThenInclude(s => s.Category).Where(r => r.UserId == userId).ToListAsync().ConfigureAwait(false);
        }
    }
}