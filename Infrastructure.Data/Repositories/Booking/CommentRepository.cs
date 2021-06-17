using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Core.Models.Booking;
using Domain.Core.Models.Users;
using Domain.Interfaces.Repositories.Booking;
using Infrastructure.Data.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Repositories.Booking
{
    public class CommentRepository : BaseRepository<Comment, int>, ICommentRepository
    {
        public CommentRepository(BookingContext context) : base(context)
        {
        }

        public override async Task<IEnumerable<Comment>> GetAllAsync()
        {
            return await _context.Comments.AsNoTracking()
                .Select(c => new Comment
                {
                    Id = c.Id,
                    Content = c.Content,
                    LeftAt = c.LeftAt,
                    ServiceId = c.ServiceId,
                    UserId = c.UserId,
                    User = new User
                    {
                        Email = c.User.Email
                    }
                }).ToListAsync();
        }

        public async Task<IEnumerable<Comment>> GetByServiceIdAsync(Guid serviceId)
        {
            return await _context.Comments.AsNoTracking().Where(c => c.ServiceId == serviceId)
                .Select(c => new Comment
                    {
                        Id = c.Id,
                        Content = c.Content,
                        LeftAt = c.LeftAt,
                        ServiceId = c.ServiceId,
                        UserId = c.UserId,
                        User = new User
                        {
                            Email = c.User.Email
                        }
                    }).ToListAsync();
        }
    }
}