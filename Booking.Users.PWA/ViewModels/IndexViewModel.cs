using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Booking.Users.PWA.ViewModels
{
    public class IndexViewModel
    {
        public IEnumerable<LeisureServiceElementViewModel> Services { get; set; }
        public IEnumerable<LeisureServiceCategoryViewModel> Categories { get; set; }
    }
}
