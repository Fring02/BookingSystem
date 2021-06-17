using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingWeb.Models
{
    public class ServicesSectionViewModel
    {
        public IEnumerable<LeisureServiceElementViewModel> Services { get; set; }
        public IEnumerable<LeisureServiceCategoryViewModel> Categories { get; set; }
    }
}
