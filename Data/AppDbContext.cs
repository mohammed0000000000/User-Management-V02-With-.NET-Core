using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using UserManagementV02.Models;

namespace UserManagementV02.Data
{
	public class AppDbContext : IdentityDbContext<ApplicationUser>
	{
		//public AppDbContext(DbContextOptions options) : base(options) {
		//}
		public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
		protected override void OnModelCreating(ModelBuilder builder) {
			base.OnModelCreating(builder);
			builder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
		}
	}
}
