using Microsoft.AspNetCore.Identity;

namespace Backend.Data.Models
{
    public class User : IdentityUser<int>
    {        
        public required string Name { get; set; }
        
        public required string Surname { get; set; }
    }
}
