using System.ComponentModel.DataAnnotations;

namespace Common.DTOs.Tasks
{
    public class UpdateTaskDTO
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; } = string.Empty;

        public string? Description { get; set; }

        [Required]
        public DateTime DueDate { get; set; }

        [Required]
        public string Priority { get; set; } = string.Empty;

        [Required]
        public string Status { get; set; } = string.Empty;
    }
}
