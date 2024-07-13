using Backend.Data;
using Backend.Data.Models;

namespace Backend.Services
{    
    public class AuditService(AppDbContext appDbContext)
    {
        private readonly AppDbContext _appDbContext = appDbContext;

        public async Task LogAsync(
            int userId,
            string action,
            string entityName,
            int entityId,
            string? details)
        {
            var auditLog = new AuditLog
            {
                UserId = userId,
                Action = action,
                EntityName = entityName,
                EntityId = entityId,
                Timestamp = DateTime.UtcNow,
                Details = details
            };

            _appDbContext.AuditLogs.Add(auditLog);

            await _appDbContext.SaveChangesAsync();
        }
    }
}
