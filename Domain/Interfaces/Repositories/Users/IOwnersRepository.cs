using Domain.Models.Users;
using System;
using System.Threading.Tasks;

namespace Domain.Interfaces.Repositories.Users
{
    public interface IOwnersRepository : IModelRepository<Owner>
    {
        Task<bool> OwnerExists(Guid ownerId);
        Task<bool> OwnerEmailExists(string Email);
        Task<Owner> GetOwnerByEmail(string Email);
    }
}
