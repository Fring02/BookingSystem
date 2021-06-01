using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain.Dtos
{
    public class LeisureServiceCategoryUpdateDto
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Specify new name of category to update")]
        public string Name { get; set; }
    }
}
