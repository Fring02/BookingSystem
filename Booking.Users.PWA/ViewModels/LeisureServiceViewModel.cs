using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Booking.Users.PWA.ViewModels
{
    public class LeisureServiceViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string Website { get; set; }
        public int Rating { get; set; }
        public int RatedCount { get; set; }
        public string Description { get; set; }
        public string WorkingTime { get; set; }
        public List<LeisureServiceImageViewModel> Images { get; set; }
        public DateTime BookingTime { get; set; } = DateTime.Now;
        public Guid CategoryId { get; set; }
        public LeisureServiceCategoryViewModel Category { get; set; }
    }
}
