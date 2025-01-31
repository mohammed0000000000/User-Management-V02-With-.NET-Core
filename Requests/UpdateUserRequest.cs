using System.ComponentModel.DataAnnotations;

namespace UserManagementV02.Requests
{
	public class UpdateUserRequest
	{
		[Required]
		[MinLength(3)]
		public string FirstName { get; set; } = string.Empty;
		[Required]
		[MinLength(3)]
		public string LastName { get; set; } = string.Empty;
	}
}
