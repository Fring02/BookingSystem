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

        public async Task<IEnumerable<ServiceImage>> GetByServiceId(Guid serviceId)
        {
            return await _context.ServicesImages.Where(i => i.ServiceId == serviceId).ToListAsync();
        }
    }
}