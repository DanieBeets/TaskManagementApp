using System.ComponentModel.DataAnnotations;

namespace Common.DTOs.Authentication
{
    public class RegisterDTO
    {
        [Required]
        public string Email { get; set; } = string.Empty;

        [Required]
        public string Password { get; set; } = string.Empty;
    }
}
