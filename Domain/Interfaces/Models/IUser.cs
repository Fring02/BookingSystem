using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Interfaces.Models
{
    public interface IUser
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
    }
}
