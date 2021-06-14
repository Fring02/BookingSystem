using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Core.Helpers.Exceptions
{
    public class AlreadyPresentException : Exception
    {
        public AlreadyPresentException(string message) : base(message)
        {

        }
    }
}
