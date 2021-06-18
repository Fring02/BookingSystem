using BookingWeb.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingWeb.Models
{
    public class BookingRequestViewModel
    {
        public Guid Id { get; set; }
        public Guid ServiceId { get; set; }
        public LeisureServiceViewModel Service { get; set; }
        public Guid UserId { get; set; }
        public UserRequestViewModel User { get; set; }
        public DateTime LeftAt { get; set; }
        public TimeSpan BookingTime { get; set; }
        public string Info { get; set; }
    }
}
