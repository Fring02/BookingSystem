using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Dtos
{
    public class LeisureServiceCategoryViewDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<LeisureServiceViewDto> Services { get; set; }
    }
}
