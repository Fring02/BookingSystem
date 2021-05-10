using Domain.Helpers;
using Domain.Interfaces.Repositories.Users;
using Domain.Models.Users;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class UsersRepository : BaseRepository<User>, IUsersRepository
    {
        public UsersRepository(BookingContext context) : base(context)
        { 
        }

        public async Task<bool> UserExistsAsync(string Email)
        {
            return await _context.Users.AnyAsync(u => u.Email == Email);
        }

        public async Task<User> GetByEmailAsync(string Email)
        {
            return await _context.Users.FirstOrDefaultAsync(x => x.Email == Email);
        }
    }
}
