namespace Common.DTOs.Tasks
{
    // TODO - revisit nullability configuration for these properties
    public class TaskDTO
    {
        public int Id { get; set; }

        public string Title { get; set; } = string.Empty;

        public string? Description { get; set; }

        public DateTime DueDate { get; set; }

        public string Priority { get; set; } = string.Empty;

        public string Status { get; set; } = string.Empty;

        public int? AssignedUserId { get; set; }
    }
}
