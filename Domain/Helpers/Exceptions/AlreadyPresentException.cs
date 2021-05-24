using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Helpers.Exceptions
{
    public class AlreadyPresentException : Exception
    {
        public AlreadyPresentException(string message) : base(message)
        {

        }
    }
}
