using System.ComponentModel.DataAnnotations;

namespace Common.DTOs.Authentication
{
    public class RegisterDTO
    {
        [Required]
        public required string Email { get; set; }

        [Required]
        public required string Password { get; set; }
    }
}
