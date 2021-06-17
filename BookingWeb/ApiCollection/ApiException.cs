using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingWeb.ApiCollection
{
    public class ApiException : Exception
    {
        public ApiException(string message) : base(message)
        {

        }
    }
}
