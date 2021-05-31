using Domain.Helpers;
using Domain.Interfaces.Repositories.Users;
using Domain.Interfaces.Services.Users;
using Domain.Models.Users;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services.Users
{
    public class OwnersService : BaseService<IOwnersRepository, Owner>, IOwnersService
    {
        public OwnersService(IOwnersRepository ownersRepository) : base(ownersRepository)
        {
        }
        public override Task<Owner> CreateAsync(Owner model)
        {
            model.Role = Roles.OWNER;
            return base.CreateAsync(model);
        }
        public async Task<bool> OwnerExists(Guid ownerId)
        {
            return await _repository.OwnerExists(ownerId).ConfigureAwait(false);
        }
    }
}
