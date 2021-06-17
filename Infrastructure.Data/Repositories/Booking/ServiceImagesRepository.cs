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
    public class ServiceImagesRepository : BaseRepository<ServiceImage, Guid>, IServiceImageRepository
    {
        public ServiceImagesRepository(BookingContext context) : base(context)
        {
        }
        public override async Task<ServiceImage> GetByIdAsync(Guid id)
        {
            return await _context.ServicesImages.AsNoTracking().Include(i => i.Service).FirstOrDefaultAsync(i => i.Id == id).ConfigureAwait(false);
        }
        public async Task<IEnumerable<ServiceImage>> GetByServiceIdAsync(Guid serviceId)
        {
           return await _context.ServicesImages.AsNoTracking().Where(i => i.ServiceId == serviceId).Include(i => i.Service).ToListAsync().ConfigureAwait(false);
        }
    }
}