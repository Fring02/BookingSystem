using Domain.Helpers;
using Domain.Interfaces.Repositories.Users;
using Domain.Interfaces.Services.Users;
using Domain.Models.Users;
using Infrastructure.Helpers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services.Users
{
    public class OwnersService : BaseService<IOwnersRepository, Owner>, IOwnersService
    {
        private readonly IOwnersRepository _ownersRepository;
        private readonly IPasswordEncryptor _encryptor;

        public OwnersService(IOwnersRepository ownersRepository, IPasswordEncryptor encryptor)
        {
            _ownersRepository = ownersRepository;
            _encryptor = encryptor;
        }
        public override Task<Owner> CreateAsync(Owner model)
        {
            model.Role = Roles.OWNER;
            return base.CreateAsync(model);
        }

        public async Task<IEnumerable<Owner>> GetAllAsync()
        {
            return await _ownersRepository.GetAllAsync().ConfigureAwait(false);
        }

        public async Task<Owner> GetByIdAsync(Guid id)
        {
            return await _ownersRepository.GetByIdAsync(id).ConfigureAwait(false);
        }

        public async Task<Owner> LoginOwnerAsync(string email, string password)
        {
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
                return null;

            var owner = await _ownersRepository.GetOwnerByEmail(email).ConfigureAwait(false);

            // check if username exists
            if (owner == null) return null;
            // check if password is correct
            if (!_encryptor.VerifyPasswordHash(password, owner.PasswordHash, owner.PasswordSalt))
                return null;

            // authentication successful
            return owner;
        }

        public async Task<bool> OwnerExists(Guid ownerId)
        {
            return await _ownersRepository.OwnerExists(ownerId).ConfigureAwait(false);
        }

        public async Task<Owner> RegisterOwnerAsync(Owner owner, string password)
        {
            // validation
            if (string.IsNullOrWhiteSpace(password))
                throw new AppException("Password is required");

            if (await _ownersRepository.OwnerEmailExists(owner.Email))
                throw new AppException("Email \"" + owner.Email + "\" is already taken");

            _encryptor.CreatePasswordHash(password, out byte[] passwordHash, out byte[] passwordSalt);

            owner.PasswordHash = passwordHash;
            owner.PasswordSalt = passwordSalt;
                await Task.WhenAll(_ownersRepository.CreateAsync(owner)).ConfigureAwait(false);
            return owner;
        }

        public async Task<bool> UpdateAsync(Owner model)
        {
            return await _ownersRepository.UpdateAsync(model).ConfigureAwait(false);
        }

        public async Task<bool> UpdateOwnerWithPasswordAsync(Owner ownerParam, string password = null)
        {
            var ownerToUpdate = await GetByIdAsync(ownerParam.Id);
            if (ownerToUpdate == null)
                throw new AppException("User not found");

            // update username if it has changed
            if (!string.IsNullOrWhiteSpace(ownerParam.Email) && ownerParam.Email != ownerToUpdate.Email)
            {
                // throw error if the new username is already taken
                if ((await _ownersRepository.GetOwnerByEmail(ownerParam.Email)) != null)
                    throw new AppException("Email " + ownerParam.Email + " is already taken");

                ownerToUpdate.Email = ownerParam.Email;
            }
            if (!string.IsNullOrWhiteSpace(ownerParam.MobilePhone)) ownerToUpdate.MobilePhone = ownerParam.MobilePhone;
            // update owner properties if provided
            if (!string.IsNullOrWhiteSpace(ownerParam.Firstname))
                ownerToUpdate.Firstname = ownerParam.Firstname;

            if (!string.IsNullOrWhiteSpace(ownerParam.Lastname))
                ownerToUpdate.Lastname = ownerParam.Lastname;

            // update password if provided
            if (!string.IsNullOrWhiteSpace(password))
            {
                CreatePasswordHash(password, out byte[] passwordHash, out byte[] passwordSalt);

                ownerToUpdate.PasswordHash = passwordHash;
                ownerToUpdate.PasswordSalt = passwordSalt;
            }
            return await _ownersRepository.UpdateAsync(ownerToUpdate).ConfigureAwait(false);
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
