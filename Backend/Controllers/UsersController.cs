using Backend.Data;
using Common.DTOs.Tasks;
using Common.DTOs.Users;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController(AppDbContext appDbContext) : ControllerBase
    {
        private readonly AppDbContext _appDbContext = appDbContext;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TaskDTO>>> GetUsers()
        {            
            var users = await
                _appDbContext
                .Users
                .Select(u => new UserDTO
                {
                    Id = u.Id,                    
                    Name = u.Name,
                    Surname = u.Surname                    
                })
                .ToListAsync();

            return Ok(users);
        }       
    }
}
