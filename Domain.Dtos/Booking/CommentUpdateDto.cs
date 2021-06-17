using System;
using System.ComponentModel.DataAnnotations;

namespace Domain.Dtos.Booking
{
    public class CommentUpdateDto
    {
        [Required(ErrorMessage = "Comment content should be not empty")]
        public string Content { get; set; }
    }
}