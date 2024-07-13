using System.ComponentModel.DataAnnotations;

namespace Backend.Models.Auth
{
    public class SignIn
    {
        [Required]
        public required string Email { get; set; }

        [Required]
        public required string Password { get; set; }
    }
}
