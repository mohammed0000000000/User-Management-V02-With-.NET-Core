using Microsoft.EntityFrameworkCore;

namespace UserManagementV02.Models
{

	[Owned]
	public class RefreshToken
	{
		public string Token { get; set; } = string.Empty;
		public DateTime CreatedOn { get; set; }
		public DateTime ExpiresOn { get; set; }
		public DateTime? RevokedOn { get; set; }


		public bool isExpired => DateTime.UtcNow >= ExpiresOn;
		public bool isActive => RevokedOn is null && !isExpired;
	}
}
