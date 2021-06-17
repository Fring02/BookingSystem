using System;
using Domain.Core.Models.Users;
using Domain.Dtos.Users;

namespace Domain.Dtos.Booking
{
    public class CommentViewDto
    {
        public int Id { get; set; }
        public Guid UserId { get; set; }
        public UserViewDto User { get; set; }
        public Guid ServiceId { get; set; }
        public LeisureServiceViewDto Service { get; set; }
        public DateTime LeftAt { get; set; }
        public string Content { get; set; }
    }
}