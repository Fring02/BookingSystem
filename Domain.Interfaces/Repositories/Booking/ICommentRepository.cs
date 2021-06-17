using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Core.Models.Booking;

namespace Domain.Interfaces.Repositories.Booking
{
    public interface ICommentRepository : IModelRepository<Comment, int>
    {
        Task<IEnumerable<Comment>> GetByServiceIdAsync(Guid serviceId);
    }
}