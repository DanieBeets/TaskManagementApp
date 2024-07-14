using Backend.Data.Models;
using Microsoft.AspNetCore.Identity;

namespace Backend
{
    public static class IdentityDataSeeder
    {
        // NOTE - security - the seed admin user credentials should be changed after initial deployment
        public static async Task SeedAsync(
            UserManager<User> userManager,
            RoleManager<Role> roleManager)
        {
            if (await roleManager.FindByNameAsync("admin") == null)
            {
                await roleManager.CreateAsync(new Role { Name = "admin", Description = "All permissions"});
            }

            if (await roleManager.FindByNameAsync("user") == null)
            {
                await roleManager.CreateAsync(new Role { Name = "user", Description = "Permission to manage tasks" });
            }

            if (await userManager.FindByNameAsync("admin") == null)
            {
                var admin = new User 
                {
                    Email = "admin@example.com",
                    UserName = "admin@example.com",
                    FirstName = "Admin Name",
                    LastName = "Admin Surname"
                };

                var result = await userManager.CreateAsync(admin, "Letmein321!!");

                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(admin, "admin");
                }
            }
        }
    }
}
