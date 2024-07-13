using Backend.Data;
using Common.DTOs.Tasks;
using Common.DTOs.Users;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController(TaskManagementDbContext appDbContext) : ControllerBase
    {
        private readonly TaskManagementDbContext _appDbContext = appDbContext;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TaskDTO>>> GetUsers()
        {            
            var users = await
                _appDbContext
                .Users
                .Select(u => new UserDTO
                {
                    Id = u.Id,
                    // TODO - adapt identity to include user name and surname in user table, also adapt registration
                    Name = u.Email ?? "No name"
                    
                })
                .ToListAsync();

            return Ok(users);
        }       
    }
}
