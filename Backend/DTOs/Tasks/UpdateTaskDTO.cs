using System.ComponentModel.DataAnnotations;

namespace Backend.DTOs.Tasks
{
    public class UpdateTaskDTO
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public required string Title { get; set; }

        public string? Description { get; set; }

        [Required]
        public DateTime DueDate { get; set; }

        [Required]
        public required string Priority { get; set; }

        [Required]
        public required string Status { get; set; }
    }
}
