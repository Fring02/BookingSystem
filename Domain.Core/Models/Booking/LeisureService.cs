using System;
using System.Collections.Generic;
using Domain.Core.Models.Users;

namespace Domain.Core.Models.Booking
{
    public class LeisureService : IEntity<Guid>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
        public string Website { get; set; }
        public double Rating { get; set; }
        public int RatedCount { get; set; }
        public string Description { get; set; }
        public string WorkingTime { get; set; }
        public Guid OwnerId { get; set; }
        public Owner Owner { get; set; }
        public Guid CategoryId { get; set; }
        public Category Category { get; set; }
        public List<ServiceImage> Images { get; set; }
        public List<Order> BookingRequests { get; set; }
        public List<Comment> Comments { get; set; }
    }
}