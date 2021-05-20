using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Booking.Users.PWA.Apis.Settings
{
    public class ApiConfiguration
    {
       public string BaseAddress { get; set; }
       public string ServicesPath { get; set; }
        public string CategoriesPath { get; set; }
        public string UsersPath { get; set; }
        public string RequestsPath { get; set; }
    }
}
