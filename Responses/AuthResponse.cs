using System.Text.Json.Serialization;

namespace UserManagementV02.Responses
{
	public class AuthResponse:BaseResponse
	{
		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
		public string? Message { get; set; }

		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
		public string? UserId { get; set; }
		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
		public string? UserName { get; set; }

		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
		public string? Email { get; set; }

		[JsonIgnore(Condition =JsonIgnoreCondition.WhenWritingNull)]
		public bool isAuthenticated { get; set; }
		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
		public string? VerificationToken { get; set; }
		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
		public DateTime? VerifiedAt { get; set; }

		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
		public string? PasswordResetToken { get; set; } = string.Empty;
		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
		public DateTime? ResetPasswordExpires { get; set; }

		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
		public string? AccessToken { get; set; }
		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
		public DateTime? AcessTokenExpireOn { get; set; }

		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
		public string? RefreshToken { get; set; }
		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
		public DateTime? RefreshTokenExpireOn { get; set; }

		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
		public List<string>? Roles { get; set; } = new List<string>();

	}
}
