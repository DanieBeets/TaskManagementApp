using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Backend.Data.Models
{
    public sealed class Role : IdentityRole<int>
    {        
        [MaxLength(250)]
        public required string Description { get; set; }
    }
}
