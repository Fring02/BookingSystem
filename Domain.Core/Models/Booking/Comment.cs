using System;
using Domain.Core.Models.Users;

namespace Domain.Core.Models.Booking
{
    public class Comment : IEntity<int>
    {
        public int Id { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
        public Guid ServiceId { get; set; }
        public LeisureService Service { get; set; }
        public DateTime LeftAt { get; set; }
        public string Content { get; set; }

        public bool IsValid => UserId != default && ServiceId != default && !string.IsNullOrEmpty(Content);
    }
}