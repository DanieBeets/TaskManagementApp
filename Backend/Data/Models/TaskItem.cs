namespace Backend.Data.Models
{
    // TODO - revisit nullability configuration for these properties
    public class TaskItem
    {
        public int Id { get; set; }

        public string Title { get; set; } = string.Empty;

        public string? Description { get; set; }

        public DateTime DueDate { get; set; }

        public string Priority { get; set; } = string.Empty;

        public string Status { get; set; } = string.Empty;

        public int? AssignedUserId { get; set; }

        public User? AssignedUser { get; set; }
    }
}
