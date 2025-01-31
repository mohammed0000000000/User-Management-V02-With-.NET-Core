﻿using System.ComponentModel.DataAnnotations;

namespace UserManagementV02.Requests
{
	public class SignUpRequest
	{
		[Required]
		[MinLength(3)]
		public string FirstName { get; set; } = string.Empty;
		[Required]
		[MinLength(3)]
		public string LastName { get; set; } = string.Empty;
		[Required]
		[EmailAddress]
		public string Email { get; set; } = string.Empty;
		[Required]
		[MinLength(8)]
		public string Password { get; set; } = string.Empty;
		[Required]
		[Compare("Password")]
		public string ConfirmPassword { get; set; } = string.Empty;
	}
}
