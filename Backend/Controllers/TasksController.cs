using Backend.Data;
using Backend.Data.Models;
using Backend.Services;
using Common.DTOs.Tasks;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TasksController(
        AppDbContext appDbContext,
        AuditService auditService) : ControllerBase
    {
        private readonly AppDbContext _appDbContext = appDbContext;

        private readonly AuditService _auditService = auditService;        

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TaskDTO>>> GetTasks(
            [FromQuery] string search,
            [FromQuery] string priority,
            [FromQuery] string status)
        {
            var query = _appDbContext.Tasks.AsQueryable();

            if (!string.IsNullOrWhiteSpace(search))
            {
                query = query.Where(t => t.Title.Contains(search) || (t.Description != null && t.Description.Contains(search)));
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

            await _auditService.LogAsync(User.GetUserId(), "Create", "Task", task.Id, null);

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

            await _auditService.LogAsync(User.GetUserId(), "Update", "Task", task.Id, null);

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
            
            await _auditService.LogAsync(User.GetUserId(), "Delete", "Task", task.Id, null);

            return NoContent();
        }

        // TODO - this should be done in update
        [HttpPut("{id}/assign")]
        public async Task<IActionResult> AssignTask(int id, [FromBody] int userId)
        {
            var task = await _appDbContext.Tasks.FindAsync(id);

            if (task == null)
            {
                return NotFound();
            }

            task.AssignedUserId = userId;

            _appDbContext.Entry(task).State = EntityState.Modified;

            await _appDbContext.SaveChangesAsync();            
            
            await _auditService.LogAsync(User.GetUserId(), "Assign", "Task", task.Id, $"Task assigned to user {userId}");

            return NoContent();
        }        
    }
}
