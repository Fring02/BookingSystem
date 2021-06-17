using System;
using System.ComponentModel.DataAnnotations;

namespace Domain.Dtos.Booking
{
    public class CommentCreateDto
    {
        [Required(ErrorMessage = "UserId should be not empty")]
        public Guid UserId { get; set; }
        [Required(ErrorMessage = "ServiceId should be not empty")]
        public Guid ServiceId { get; set; }
        public DateTime LeftAt { get; set; } = DateTime.Now;
        [Required(ErrorMessage = "Comment content should be not empty")]
        public string Content { get; set; }
    }
}