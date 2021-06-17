using System;
using System.Threading.Tasks;
using Domain.Core.Models.Users;
using Domain.Interfaces.Repositories.Users;
using Infrastructure.Data.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Repositories.Users
{
    public class OwnersRepository : BaseRepository<Owner, Guid>, IOwnersRepository
    {
        public OwnersRepository(BookingContext context) : base(context)
        {

        }
        public async Task<bool> OwnerExists(Guid ownerId)
        {
            return await _context.Owners.AnyAsync(o => o.Id == ownerId).ConfigureAwait(false);
        }
    }
}
