using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Booking.Users.PWA.ViewModels
{
    public class FilterFormViewModel
    {
        public string CategoryName { get; set; }
        public string WorkingTime { get; set; }
        public int? Rating { get; set; }
        public IEnumerable<LeisureServiceCategoryViewModel> Categories { get; set; }
    }
}
