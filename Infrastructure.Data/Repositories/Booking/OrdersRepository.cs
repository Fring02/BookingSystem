using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Core.Models.Booking;
using Domain.Interfaces.Repositories.Booking;
using Infrastructure.Data.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Repositories.Booking
{
    public class OrdersRepository : BaseRepository<Order, Guid>, IOrdersRepository
    {
        public OrdersRepository(BookingContext context) : base(context)
        {
        }
        public override async Task<Order> GetByIdAsync(Guid id)
        {
            return await _context.Orders.AsNoTracking().Include(r => r.Service).FirstOrDefaultAsync(r => r.Id == id).ConfigureAwait(false);
        }
        public override async Task<IEnumerable<Order>> GetAllAsync()
        {
            return await _context.Orders.AsNoTracking().Include(r => r.Service).ToListAsync().ConfigureAwait(false);
        }
        public async Task<IEnumerable<Order>> GetByServiceIdAsync(Guid serviceId)
        {
            return await _context.Orders.AsNoTracking().Include(r => r.Service).ThenInclude(s => s.Category).Where(r => r.ServiceId == serviceId).ToListAsync().ConfigureAwait(false);
        }

        public async Task<bool> HasRequestAsync(Order request)
        {
            return await _context.Orders.AnyAsync(r => r.ServiceId == request.ServiceId && r.UserId == request.UserId).ConfigureAwait(false);
        }

        public async Task<IEnumerable<Order>> GetByUserIdAsync(Guid userId)
        {
            return await _context.Orders.AsNoTracking().Include(r => r.Service).ThenInclude(s => s.Category).Where(r => r.UserId == userId).ToListAsync().ConfigureAwait(false);
        }
    }
}