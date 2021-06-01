using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain.Dtos
{
    public class LeisureServiceCategoryCreateDto
    {
        [Required(ErrorMessage = "Enter category name")]
        [MaxLength(40, ErrorMessage = "A name of category should be 40 characters maximum")]
        public string Name { get; set; }
    }
}
