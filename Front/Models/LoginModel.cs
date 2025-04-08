using System.ComponentModel.DataAnnotations;

namespace Front.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Username is required.")]
        [MinLength(4, ErrorMessage = "Username must have at least 4 characters.")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [MinLength(5, ErrorMessage = "Password must have at least 5 characters.")]
        public string Password { get; set; }
    }
}
