﻿namespace Backend.Data.Models
{
    // TODO - revisit nullability configuration for these properties
    public class AuditLog
    {
        public int Id { get; set; }

        public string UserId { get; set; }

        public string Action { get; set; }

        public string EntityName { get; set; }

        public string EntityId { get; set; }

        public DateTime Timestamp { get; set; }

        public string Details { get; set; }
    }
}
