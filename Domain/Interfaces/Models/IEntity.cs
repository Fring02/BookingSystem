using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Interfaces.Models
{
    public interface IEntity<TId>
    {
        public TId Id { get; set; }
    }
}
