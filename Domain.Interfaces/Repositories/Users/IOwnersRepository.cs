using Domain.Core.Models.Booking;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Domain.Core.Models.Users;

namespace Domain.Interfaces.Repositories.Users
{
    public interface IOwnersRepository : IModelRepository<Owner, Guid>
    {
        Task<bool> OwnerExists(Guid ownerId);
    }
}
