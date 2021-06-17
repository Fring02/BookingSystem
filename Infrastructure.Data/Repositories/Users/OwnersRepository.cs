using Domain.Interfaces.Repositories.Users;
using Domain.Models.Users;
using Infrastructure.Data.Contexts;
using Infrastructure.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace Infrastructure.Repositories.Users
{
    public class OwnersRepository : BaseRepository<Owner, Guid>, IOwnersRepository
    {
        public OwnersRepository(BookingContext context) : base(context)
        {

        }

        public async Task<Owner> GetOwnerByEmail(string Email)
        {
            return await _context.Owners.FirstOrDefaultAsync(x => x.Email == Email).ConfigureAwait(false);
        }

        public async Task<bool> OwnerEmailExists(string Email)
        {
            return await _context.Owners.AnyAsync(u => u.Email == Email).ConfigureAwait(false);
        }

        public async Task<bool> OwnerExists(Guid ownerId)
        {
            return await _context.Owners.AnyAsync(o => o.Id == ownerId).ConfigureAwait(false);
        }
    }
}
