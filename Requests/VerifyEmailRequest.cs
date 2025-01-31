using System.ComponentModel.DataAnnotations;

namespace UserManagementV02.Requests
{
	public class VerifyEmailRequest
	{
		[Required]
		public string Email { get; set; } = string.Empty;
		[Required]
		public string Token { get; set; } = string.Empty;
	}
}
