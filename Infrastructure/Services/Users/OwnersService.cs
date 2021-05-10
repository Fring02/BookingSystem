using Domain.Interfaces.Repositories.Users;
using Domain.Interfaces.Services.Users;
using Domain.Models.Users;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services.Users
{
    public class OwnersService : IOwnersService
    {
        private readonly IOwnersRepository _ownersRepository;

        public OwnersService(IOwnersRepository ownersRepository)
        {
            _ownersRepository = ownersRepository;
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

        public async Task<bool> OwnerExists(Guid ownerId)
        {
            return await _ownersRepository.OwnerExists(ownerId).ConfigureAwait(false);
        }

        public async Task<bool> UpdateAsync(Owner model)
        {
            return await _ownersRepository.UpdateAsync(model).ConfigureAwait(false);
        }
    }
}
