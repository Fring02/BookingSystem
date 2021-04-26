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
    public class ServiceImagesRepository : BaseRepository<ServiceImage>, IServiceImageRepository
    {
        public ServiceImagesRepository(BookingContext context) : base(context)
        {
        }
        public override async Task<ServiceImage> GetByIdAsync(Guid id)
        {
            return await _context.ServicesImages.Include(i => i.Service).FirstOrDefaultAsync(i => i.Id == id);
        }
        public async Task<IEnumerable<ServiceImage>> GetByServiceId(Guid serviceId)
        {
            var images = await _context.ServicesImages.Where(i => i.ServiceId == serviceId).Include(i => i.Service).ToListAsync();
            return images;
        }
    }
}