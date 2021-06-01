using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingWeb.ApiCollection.Settings
{
    public class ApiSettings
    {
        public string BaseAddress { get; set; }
        public string ServicesPath { get; set; }
        public string CategoriesPath { get; set; }
        public string UsersPath { get; set; }
        public string RequestsPath { get; set; }
    }
}
