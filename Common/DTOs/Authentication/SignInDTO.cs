using System.ComponentModel.DataAnnotations;

namespace Common.DTOs.Authentication
{
    public class SignInDTO
    {
        [Required]
        public string Email { get; set; } = string.Empty;

        [Required]
        public string Password { get; set; } = string.Empty;
    }
}
