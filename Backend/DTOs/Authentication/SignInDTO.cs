using System.ComponentModel.DataAnnotations;

namespace Backend.DTOs.Authentication
{
    public class SignInDTO
    {
        [Required]
        public required string Email { get; set; }

        [Required]
        public required string Password { get; set; }
    }
}
