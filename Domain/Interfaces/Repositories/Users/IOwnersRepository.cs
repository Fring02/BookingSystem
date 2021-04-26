using Domain.Models.Users;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Repositories.Users
{
    public interface IOwnersRepository : IModelRepository<Owner>
    {
        Task<bool> OwnerExists(Guid ownerId);
    }
}
