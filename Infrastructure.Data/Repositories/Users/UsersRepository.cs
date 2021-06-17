using System;
using System.Threading.Tasks;
using Domain.Core.Models.Users;
using Domain.Interfaces.Repositories.Users;
using Infrastructure.Data.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Repositories.Users
{
    public class UsersRepository : BaseRepository<User, Guid>, IUsersRepository
    {
        public UsersRepository(BookingContext context) : base(context)
        { 
        }
        public override async Task<User> GetByIdAsync(Guid id)
        {
            return await _context.Users.AsNoTracking().Include(u => u.BookingRequests).ThenInclude(r => r.Service).FirstOrDefaultAsync(u => u.Id == id).ConfigureAwait(false);
        }
        public async Task<bool> UserExistsAsync(string email)
        {
            return await _context.Users.AnyAsync(u => u.Email == email).ConfigureAwait(false);
        }

        public async Task<User> GetByEmailAsync(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(x => x.Email == email).ConfigureAwait(false);
        }
    }
}
