using Backend.Data.Models;
using Microsoft.AspNetCore.Identity;

namespace Backend
{
    public static class RoleInitializer
    {
        // NOTE - security - the initial admin user credentials should be changed after initial deployment
        public static async Task InitializeAsync(
            UserManager<User> userManager,
            RoleManager<Role> roleManager)
        {
            if (await roleManager.FindByNameAsync("admin") == null)
            {
                await roleManager.CreateAsync(new Role { Name = "admin"});
            }

            if (await roleManager.FindByNameAsync("user") == null)
            {
                await roleManager.CreateAsync(new Role { Name = "user" });
            }

            if (await userManager.FindByNameAsync("admin") == null)
            {
                var admin = new User 
                {
                    Email = "admin@example.com",
                    UserName = "admin",
                    Name = "Admin Name",
                    Surname = "Admin Surname"
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
