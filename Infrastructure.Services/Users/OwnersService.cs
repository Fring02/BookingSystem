using Domain.Core.Helpers;
using Domain.Core.Models.Booking;
using Domain.Interfaces.Repositories.Users;
using Domain.Interfaces.Services.Users;
using System;
using System.Threading.Tasks;
using Domain.Core.Models.Users;

namespace Infrastructure.Services.Users
{

    public class OwnersService : BaseService<IOwnersRepository, Owner, Guid>, IOwnersService
    {
        public OwnersService(IOwnersRepository ownersRepository) : base(ownersRepository)
        {
        }
        public async Task<bool> OwnerExists(Guid ownerId)
        {
            return await _repository.OwnerExists(ownerId).ConfigureAwait(false);
        }
    }
}
