using System.ComponentModel.DataAnnotations;

namespace Backend.Data.Models
{
    // TODO - revisit nullability configuration for these properties
    public class AuditLog
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        [Required]
        public required string Action { get; set; }

        [Required]
        public required string EntityName { get; set; }

        public int EntityId { get; set; }

        [Required]
        public required DateTime Timestamp { get; set; }

        public string? Details { get; set; }
    }
}
