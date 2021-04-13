using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models.Booking
{
    public class LeisureServiceCategory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Guid ServiceId { get; set; }
        public LeisureService Service { get; set; }
    }
}
