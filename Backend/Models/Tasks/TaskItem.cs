using Microsoft.AspNetCore.Identity;

namespace Backend.Models.Tasks
{
    public class TaskItem
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DueDate { get; set; }
        public string Priority { get; set; }
        public string Status { get; set; }
        public string AssignedUserId { get; set; }
        public IdentityUser AssignedUser { get; set; }
    }
}
