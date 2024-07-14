using Backend.Data;
using Backend.Data.Models;
using Microsoft.EntityFrameworkCore;

// TODO - this is not in use yet - determine if it should be used
namespace Backend.Services
{
    public class TaskService(AppDbContext appDbContext)
    {
        private readonly AppDbContext _appDbContext = appDbContext;

        public async Task<IEnumerable<TaskItem>> GetTasksAsync()
        {
            return await _appDbContext.Tasks.ToListAsync();
        }

        public async Task<TaskItem?> GetTaskByIdAsync(int id)
        {
            return await _appDbContext.Tasks.FindAsync(id);
        }

        public async Task AddTaskAsync(TaskItem task)
        {
            _appDbContext.Tasks.Add(task);

            await _appDbContext.SaveChangesAsync();
        }

        public async Task UpdateTaskAsync(TaskItem task)
        {
            _appDbContext.Entry(task).State = EntityState.Modified;

            await _appDbContext.SaveChangesAsync();
        }

        public async Task DeleteTaskAsync(int id)
        {
            var task = await _appDbContext.Tasks.FindAsync(id);

            if (task != null)
            {
                _appDbContext.Tasks.Remove(task);
                await _appDbContext.SaveChangesAsync();
            }
        }
        
        public async Task<IEnumerable<TaskItem>> GetTasksByStatusAsync(string status)
        {
            return await _appDbContext.Tasks.Where(t => t.Status == status).ToListAsync();
        }
        
        public async Task AssignTaskToUserAsync(int taskId, int userId)
        {
            var task = await _appDbContext.Tasks.FindAsync(taskId);

            if (task != null)
            {
                task.AssignedUserId = userId;

                _appDbContext.Entry(task).State = EntityState.Modified;

                await _appDbContext.SaveChangesAsync();
            }
        }        

        public async Task<int> GetTotalTasksCountAsync()
        {
            return await _appDbContext.Tasks.CountAsync();
        }
    }
}