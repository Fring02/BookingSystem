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

        public async Task<bool> UpdateUserWithPasswordAsync(User userParam, string password = null)
        {
            var user = await GetByIdAsync(userParam.Id);
            if (user == null)
                throw new AppException("User not found");

            // update username if it has changed
            if (!string.IsNullOrWhiteSpace(userParam.Email) && userParam.Email != user.Email)
            {
                // throw error if the new username is already taken
                if (await _context.Users.AnyAsync(x => x.Email == userParam.Email))
                    throw new AppException("Email " + userParam.Email + " is already taken");

                user.Email = userParam.Email;
            }

            // update user properties if provided
            if (!string.IsNullOrWhiteSpace(userParam.Firstname))
                user.Firstname = userParam.Firstname;

            if (!string.IsNullOrWhiteSpace(userParam.Lastname))
                user.Lastname = userParam.Lastname;

            // update password if provided
            if (!string.IsNullOrWhiteSpace(password))
            {
                CreatePasswordHash(password, out byte[] passwordHash, out byte[] passwordSalt);

                user.PasswordHash = passwordHash;
                user.PasswordSalt = passwordSalt;
            }
            _context.Users.Update(user);
            return await _context.SaveChangesAsync() > 0;
            
        }

        private static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            if (password == null) throw new ArgumentNullException("password");
            if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException("Value cannot be empty or whitespace only string.", "password");

            using var hmac = new System.Security.Cryptography.HMACSHA512();
            passwordSalt = hmac.Key;
            passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
        }
    }
}
