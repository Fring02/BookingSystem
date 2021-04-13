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

        public async Task<IEnumerable<BookingRequest>> GetByServiceId(Guid serviceId)
        {
            return await _context.BookingRequests.Where(r => r.ServiceId == serviceId).ToListAsync();
        }
    }
}