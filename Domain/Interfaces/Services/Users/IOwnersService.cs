using Domain.Interfaces.Repositories.Users;
using Domain.Models.Users;
using System;
using System.Threading.Tasks;

namespace Domain.Interfaces.Services.Users
{
    public interface IOwnersService : IModelService<IOwnersRepository, Owner>
    {
        Task<bool> OwnerExists(Guid ownerId);
        Task<Owner> LoginOwnerAsync(string email, string password);
        Task<Owner> RegisterOwnerAsync(Owner owner, string password);
        Task<bool> UpdateOwnerWithPasswordAsync(Owner ownerParam, string password = null);
    }
}
