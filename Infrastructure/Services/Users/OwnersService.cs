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

        public Task<Owner> CreateAsync(Owner model)
        {
            return _ownersRepository.CreateAsync(model);
        }

        public Task<bool> DeleteAsync(Owner model)
        {
            return _ownersRepository.DeleteAsync(model);
        }

        public Task<IEnumerable<Owner>> GetAllAsync()
        {
            return _ownersRepository.GetAllAsync();
        }

        public Task<Owner> GetByIdAsync(Guid id)
        {
            return _ownersRepository.GetByIdAsync(id);
        }

        public Task<bool> OwnerExists(Guid ownerId)
        {
            return _ownersRepository.OwnerExists(ownerId);
        }

        public Task<bool> UpdateAsync(Owner model)
        {
            return _ownersRepository.UpdateAsync(model);
        }
    }
}
