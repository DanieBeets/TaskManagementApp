using Backend.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Backend.Data
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : IdentityDbContext<User, Role, int>(options)
    {
        public DbSet<TaskItem> Tasks { get; set; }

        public DbSet<AuditLog> AuditLogs { get; set; }
    }
}
