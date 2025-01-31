using System.ComponentModel.DataAnnotations;

namespace UserManagementV02.Requests
{
	public class SignInRequest
	{
		[Required]
		[EmailAddress]
		public string Email { get; set; } = string.Empty;

		[Required]
		[MinLength(8)]
		public string Password { get; set; } = string.Empty;
	}
}
