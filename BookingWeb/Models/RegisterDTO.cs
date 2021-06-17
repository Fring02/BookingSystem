using System.ComponentModel.DataAnnotations;

namespace BookingWeb.Models
{
    public class RegisterDTO
    {
        [Required]
        public string Firstname { get; set; }

        [Required]
        public string Lastname { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
        [Required]
        public string MobilePhone { get; set; }
    }
}
