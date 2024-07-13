using Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.Data
{    
    public class TaskManagementDbContext(DbContextOptions<TaskManagementDbContext> options) : DbContext(options)
    {
        public DbSet<TaskItem> Tasks { get; set; }
    }
}
