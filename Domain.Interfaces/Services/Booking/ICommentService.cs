using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Core.Models.Booking;
using Domain.Interfaces.Repositories.Booking;

namespace Domain.Interfaces.Services.Booking
{
    public interface ICommentService : IModelService<ICommentRepository, Comment, int>
    {
        Task<IEnumerable<Comment>> GetByServiceIdAsync(Guid serviceId);
    }
}