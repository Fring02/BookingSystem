using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingWeb.Models
{
    public class LeisureServiceElementViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Rating { get; set; }
        public string WorkingTime { get; set; }
        public Guid CategoryId { get; set; }
        public LeisureServiceCategoryViewModel Category { get; set; }
        public List<LeisureServiceImageViewModel> Images { get; set; }
        public string ImageUrl { get; set; }
    }
}
