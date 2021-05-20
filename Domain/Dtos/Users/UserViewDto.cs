using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Dtos.Users
{
    public class UserViewDto
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string MobilePhone { get; set; }
        public List<BookingRequestViewDto> BookingRequests { get; set; }
    }
}
