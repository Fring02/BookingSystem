using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models.Booking
{
    public class LeisureServiceCategory
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<LeisureService> Services { get; set; }
    }
}
