using Domain.Helpers;
using Domain.Interfaces.Repositories.Users;
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
    public class UsersService : IUserService
    {
        private readonly IUsersRepository _userRepository;
        private readonly NotificationService notificationService;
        public UsersService(IUsersRepository userRepository, NotificationService notificationService)
        {
            _userRepository = userRepository;
            this.notificationService = notificationService;
        }

        public async Task<User> CreateAsync(User model)
        {
            return await _userRepository.CreateAsync(model).ConfigureAwait(false);
        }

        public async Task<bool> DeleteAsync(User model)
        {
            return await _userRepository.DeleteAsync(model).ConfigureAwait(false);
        }
        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _userRepository.GetAllAsync().ConfigureAwait(false);
        }

        public async Task<User> GetByIdAsync(Guid id)
        {
            return await _userRepository.GetByIdAsync(id).ConfigureAwait(false);
        }

        public async Task<User> LoginAsync(string email, string password)
        {
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
                return null;

            var user = await _userRepository.GetByEmailAsync(email).ConfigureAwait(false);

            // check if username exists
            if (user == null) return null;
            // check if password is correct
            if (!PasswordHashService.VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
                return null;

            // authentication successful
            return user;
        }

        public async Task<User> RegisterAsync(User user, string password)
        {
            // validation
            if (string.IsNullOrWhiteSpace(password))
                throw new AppException("Password is required");

            if (await _userRepository.UserExistsAsync(user.Email))
                throw new AppException("Email \"" + user.Email + "\" is already taken");

            PasswordHashService.CreatePasswordHash(password, out byte[] passwordHash, out byte[] passwordSalt);

            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;
            await Task.WhenAll(notificationService.SendEmailAsync(user.Email), _userRepository.CreateAsync(user)).ConfigureAwait(false);
            return user;
        }

        public async Task<bool> UpdateAsync(User userParam)
        {
            return await _userRepository.UpdateAsync(userParam).ConfigureAwait(false);
        }


        public async Task<bool> UpdateUserWithPasswordAsync(User userParam, string password = null)
        {
            return await _userRepository.UpdateUserWithPasswordAsync(userParam, password).ConfigureAwait(false);
        }
        

        
    }
}
