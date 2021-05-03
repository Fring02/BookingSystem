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
    public class BookingRequestsRepository : BaseRepository<BookingRequest>, IBookingRequestsRepository
    {
        public BookingRequestsRepository(BookingContext context) : base(context)
        {
        }
        public override async Task<BookingRequest> GetByIdAsync(Guid id)
        {
            return await _context.BookingRequests.Include(r => r.Service).FirstOrDefaultAsync(r => r.Id == id);
        }
        public override async Task<IEnumerable<BookingRequest>> GetAllAsync()
        {
            return await _context.BookingRequests.Include(r => r.Service).ToListAsync();
        }
        public async Task<IEnumerable<BookingRequest>> GetByServiceId(Guid serviceId)
        {
            return await _context.BookingRequests.Where(r => r.ServiceId == serviceId).ToListAsync();
        }

        public async Task<bool> HasRequest(BookingRequest request)
        {
            return await _context.BookingRequests.AnyAsync(r => r.ServiceId == request.ServiceId && r.UserId == request.UserId);
        }
    }
}