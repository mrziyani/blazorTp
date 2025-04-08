using System.ComponentModel.DataAnnotations;

namespace Front.Models
{
    public class User
    {
        [Required(ErrorMessage = "Username is required.")]
        [MinLength(4, ErrorMessage = "Username must have at least 4 characters.")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Enter a valid email address.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [MinLength(5, ErrorMessage = "Password must have at least 5 characters.")]
        public string Password { get; set; }
    }
}
