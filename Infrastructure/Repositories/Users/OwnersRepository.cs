using Domain.Interfaces.Repositories.Users;
using Domain.Models.Users;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories.Users
{
    public class OwnersRepository : BaseRepository<Owner>, IOwnersRepository
    {
        public OwnersRepository(BookingContext context) : base(context)
        {

        }
        public async Task<bool> OwnerExists(Guid ownerId)
        {
            return await _context.LeisureServicesOwners.AnyAsync(o => o.Id == ownerId).ConfigureAwait(false);
        }
    }
}
