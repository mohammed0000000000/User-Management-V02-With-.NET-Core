
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using UserManagementV02.Data;
using UserManagementV02.Middelwares;
using UserManagementV02.Models;
using UserManagementV02.Settings;

namespace UserManagementV02
{
	public class Program
	{
		public static void Main(string[] args) {
			var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.
			builder.Services.AddControllers();
			// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
			builder.Services.AddEndpointsApiExplorer();
			builder.Services.AddSwaggerGen();

			// Add Logging
			builder.Logging.ClearProviders();
			builder.Logging.AddConsole();

			// -------
			builder.Services.Configure<JwtSettings>(builder.Configuration.GetSection("JWTSettings"));
			builder.Services.Configure<MailSettings>(builder.Configuration.GetSection("MailSettings"));
			// Register DbContext With DI
			builder.Services.AddDbContext<AppDbContext>(options => {
				options.UseSqlServer(builder.Configuration.GetConnectionString("default"));
			});
			// Register Identity Services
			builder.Services.AddIdentity<ApplicationUser, IdentityRole>().
			AddEntityFrameworkStores<AppDbContext>().
			AddDefaultTokenProviders(); /// to automatic generate token 
			builder.Services.Configure<DataProtectionTokenProviderOptions>(options =>
			{
				options.TokenLifespan = TimeSpan.FromHours(2); // Set token expiration time
			});

			
			var app = builder.Build();

			// Configure the HTTP request pipeline.
			if (app.Environment.IsDevelopment()) {
				app.UseSwagger();
				app.UseSwaggerUI();
			}

			app.UseHttpsRedirection();

			// Register Global Exception Handling
			app.UseMiddleware<ExceptionMiddleware>();
			app.UseAuthorization();

			app.MapControllers();

			app.Run();
		}
	}
}
