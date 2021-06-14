using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Core.Helpers.Exceptions
{
    public class EntityNotFoundException : Exception
    {
        public EntityNotFoundException(string message) : base(message)
        {

        }
    }
}
