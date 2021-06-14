using System;
using System.Collections.Generic;

namespace Domain.Core.Models.Booking
{
    public class LeisureServiceCategory : IEntity<Guid>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<LeisureService> Services { get; set; }
    }
}
