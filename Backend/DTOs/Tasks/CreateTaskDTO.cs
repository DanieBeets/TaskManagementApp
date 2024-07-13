using System.ComponentModel.DataAnnotations;

namespace Backend.DTOs.Tasks
{
    public class CreateTaskDTO
    {
        [Required]
        public required string Title { get; set; }

        public string? Description { get; set; }

        [Required]
        public DateTime DueDate { get; set; }

        [Required]
        public required string Priority { get; set; }
    }
}
