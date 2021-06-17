using Domain.Core.Models.Booking;
using Domain.Interfaces.Repositories.Users;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Domain.Core.Models.Users;

namespace Domain.Interfaces.Services.Users
{
    public interface IOwnersService : IModelService<IOwnersRepository, Owner, Guid>
    {
        Task<bool> OwnerExists(Guid ownerId);
    }
}
