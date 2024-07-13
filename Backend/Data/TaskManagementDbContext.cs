using Backend.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Backend.Data
{
    public class TaskManagementDbContext(DbContextOptions<TaskManagementDbContext> options) : IdentityDbContext<IdentityUser>(options)
    {
        public DbSet<TaskItem> Tasks { get; set; }
    }
}
