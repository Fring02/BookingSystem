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
    public class OwnersService : IOwnersService
    {
        private readonly IOwnersRepository _ownersRepository;
        private readonly IPasswordEncryptor _encryptor;

        public OwnersService(IOwnersRepository ownersRepository, IPasswordEncryptor encryptor)
        {
            _ownersRepository = ownersRepository;
            _encryptor = encryptor;
        }

        public async Task<Owner> CreateAsync(Owner model)
        {
            return await _ownersRepository.CreateAsync(model).ConfigureAwait(false);
        }

        public async Task<bool> DeleteAsync(Owner model)
        {
            return await _ownersRepository.DeleteAsync(model).ConfigureAwait(false);
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

        public Task<bool> UpdateOwnerWithPasswordAsync(Owner ownerParam, string password = null)
        {
            throw new NotImplementedException();
        }
    }
}
