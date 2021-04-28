using Domain.Helpers;
using Domain.Interfaces.Services;
using Domain.Models.Users;
using Infrastructure.Data;
using Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class UserService : IUserService
    {
        private BookingContext _context;
        private UserRepository _userRepository;
        public UserService(BookingContext context, UserRepository userRepository)
        {
            _context = context;
            _userRepository = userRepository;
        }

        public Task<User> CreateAsync(User model)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> DeleteAsync(User model)
        {
            return await _userRepository.DeleteAsync(model);
        }

        public async Task<bool> DeleteByIdAsync(Guid id)
        {
            return await _userRepository.DeleteByIdAsync(id);
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _userRepository.GetAllAsync();
        }

        public async Task<User> GetByIdAsync(Guid id)
        {
            return await _userRepository.GetByIdAsync(id);
        }

        public async Task<User> Login(string email, string password)
        {
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
                return null;

            var user = _userRepository.GetByEmailAsync(email);

            // check if username exists
            if (user == null)
                return null;
            var pass = _context.Users.SingleOrDefault(x => x.Email == email);
            // check if password is correct
            if (!VerifyPasswordHash(password, pass.PasswordHash, pass.PasswordSalt))
                return null;

            // authentication successful
            return await user;
        }

        public async Task<User> Register(User user, string password)
        {
            // validation
            if (string.IsNullOrWhiteSpace(password))
                throw new AppException("Password is required");

            if (await _userRepository.GetAnyEmail(user.Email))
                throw new AppException("Email \"" + user.Email + "\" is already taken");

            byte[] passwordHash, passwordSalt;
            CreatePasswordHash(password, out passwordHash, out passwordSalt);

            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            _context.Users.Add(user);
            _context.SaveChanges();

            return user;
        }

        public async Task<bool> UpdateAsync(User userParam)
        {
            return await _userRepository.UpdateAsync(userParam);
        }


        public async Task<bool> UpdateUser(User userParam, string password = null)
        {
            return await _userRepository.UpdateUser(userParam, password);
        }



        //Private helpers methods
        private static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            if (password == null) throw new ArgumentNullException("password");
            if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException("Value cannot be empty or whitespace only string.", "password");

            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        private static bool VerifyPasswordHash(string password, byte[] storedHash, byte[] storedSalt)
        {
            if (password == null) throw new ArgumentNullException("password");
            if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException("Value cannot be empty or whitespace only string.", "password");
            if (storedHash.Length != 64) throw new ArgumentException("Invalid length of password hash (64 bytes expected).", "passwordHash");
            if (storedSalt.Length != 128) throw new ArgumentException("Invalid length of password salt (128 bytes expected).", "passwordHash");

            using (var hmac = new System.Security.Cryptography.HMACSHA512(storedSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != storedHash[i]) return false;
                }
            }

            return true;
        }

        
    }
}
