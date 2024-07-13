using Backend.Data;
using Backend.Data.Models;
using Backend.DTOs.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TasksController(TaskManagementDbContext appDbContext) : ControllerBase
    {
        private readonly TaskManagementDbContext _appDbContext = appDbContext;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TaskDTO>>> GetTasks(
            [FromQuery] string search,
            [FromQuery] string priority,
            [FromQuery] string status)
        {
            var query = _appDbContext.Tasks.AsQueryable();

            if (!string.IsNullOrWhiteSpace(search))
            {
                query = query.Where(t => t.Title.Contains(search) || t.Description.Contains(search));
            }

            if (!string.IsNullOrWhiteSpace(priority))
            {
                query = query.Where(t => t.Priority == priority);
            }

            if (!string.IsNullOrWhiteSpace(status))
            {
                query = query.Where(t => t.Status == status);
            }

            var tasks = await
                query
                .Select(t => new TaskDTO
                {
                    Id = t.Id,
                    Title = t.Title,
                    Description = t.Description,
                    DueDate = t.DueDate,
                    Priority = t.Priority,
                    Status = t.Status,
                    AssignedUserId = t.AssignedUserId
                })
                .ToListAsync();

            return Ok(tasks);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TaskDTO>> GetTask(int id)
        {
            var task = await
                _appDbContext.Tasks
                .Select(t => new TaskDTO
                {
                    Id = t.Id,
                    Title = t.Title,
                    Description = t.Description,
                    DueDate = t.DueDate,
                    Priority = t.Priority,
                    Status = t.Status,
                    AssignedUserId = t.AssignedUserId
                })
                .FirstOrDefaultAsync(t => t.Id == id);

            if (task == null)
            {
                return NotFound();
            }

            return Ok(task);
        }

        [HttpPost]
        public async Task<ActionResult<TaskDTO>> CreateTask(CreateTaskDTO ct)
        {
            var task = new TaskItem
            {
                Title = ct.Title,
                Description = ct.Description,
                DueDate = ct.DueDate,
                Priority = ct.Priority,
                Status = "Not Started"
            };

            _appDbContext.Tasks.Add(task);

            await _appDbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetTask), new { id = task.Id }, task);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTask(int id, UpdateTaskDTO ut)
        {
            if (id != ut.Id)
            {
                return BadRequest();
            }

            var task = await _appDbContext.Tasks.FindAsync(id);

            if (task == null)
            {
                return NotFound();
            }

            task.Title = ut.Title;
            task.Description = ut.Description;
            task.DueDate = ut.DueDate;
            task.Priority = ut.Priority;
            task.Status = ut.Status;

            _appDbContext.Entry(task).State = EntityState.Modified;

            await _appDbContext.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTask(int id)
        {
            var task = await _appDbContext.Tasks.FindAsync(id);

            if (task == null)
            {
                return NotFound();
            }

            _appDbContext.Tasks.Remove(task);

            await _appDbContext.SaveChangesAsync();

            return NoContent();
        }

        [HttpPut("{id}/assign")]
        public async Task<IActionResult> AssignTask(int id, [FromBody] string userId)
        {
            var task = await _appDbContext.Tasks.FindAsync(id);

            if (task == null)
            {
                return NotFound();
            }

            task.AssignedUserId = userId;

            _appDbContext.Entry(task).State = EntityState.Modified;

            await _appDbContext.SaveChangesAsync();

            return NoContent();
        }
    }
}
