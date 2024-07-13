using Backend.Data;
using Backend.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuditLogController(AppDbContext appDbContext) : ControllerBase
    {
        private readonly AppDbContext _appDbContext = appDbContext;

        [HttpGet]
        public async Task<ActionResult<List<AuditLog>>> GetAuditLogs()
        {
            return await _appDbContext.AuditLogs.ToListAsync();
        }
    }
}
