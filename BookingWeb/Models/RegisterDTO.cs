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
        [DataType(DataType.Password)]
        [StringLength(15, ErrorMessage = "The {0} must be at least {2} characters long.",MinimumLength = 6)]
        public string Password { get; set; }
        [Required]
        public string MobilePhone { get; set; }
    }
}
