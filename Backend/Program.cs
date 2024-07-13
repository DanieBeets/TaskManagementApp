using Backend.Data;
using Backend.Data.Models;
using Backend.Hubs;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Backend
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var jwtIssuer = builder.Configuration["Jwt:Issuer"]?.ToString() ?? throw new Exception("'Jwt:Issuer' is missing from the configuration file");
            var jwtAudience = builder.Configuration["Jwt:Audience"]?.ToString() ?? throw new Exception("'Jwt:Audience' is missing from the configuration file");
            var jwtKey = builder.Configuration["Jwt:Key"]?.ToString() ?? throw new Exception("'Jwt:Key' is missing from the configuration file");

            builder.Services.AddDbContext<AppDbContext>(
                options => options.UseSqlite(builder.Configuration.GetConnectionString("TaskManagementConnection")));
            
            builder.Services.AddIdentity<User, Role>()
                .AddEntityFrameworkStores<AppDbContext>()
                .AddDefaultTokenProviders();
                        
            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = jwtIssuer,
                    ValidAudience = jwtAudience,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey))
                };
            });
           
            builder.Services.AddControllers();
            
            builder.Services.AddEndpointsApiExplorer();

            builder.Services.AddSwaggerGen();

            builder.Services.AddSignalR();
            
            var app = builder.Build();
            
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapHub<NotificationHub>("/notificationHub");

            app.MapControllers();

            // seed users and roles
            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var userManager = services.GetRequiredService<UserManager<IdentityUser>>();
                var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
                RoleInitializer.InitializeAsync(userManager, roleManager).Wait();
            }

            app.Run();
        }
    }
}