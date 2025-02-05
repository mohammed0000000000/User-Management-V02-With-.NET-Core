using Microsoft.AspNetCore.Identity;

namespace UserManagementV02.Models
{
	public class ApplicationUser : IdentityUser
	{
		public string FirstName { get; set; } = string.Empty;
		public string LastName { get; set; } = string.Empty;
		public bool IsAccountDisabled { get; set; }
		public DateTime? LockoutEnd { get; set; }

        public bool isVerify { get; set; }
        public ICollection<RefreshToken>? RefreshTokens { get; set; } = new List<RefreshToken>();
	}
}
