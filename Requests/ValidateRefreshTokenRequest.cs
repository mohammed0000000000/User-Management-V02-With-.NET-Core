using UserManagementV02.Models;

namespace UserManagementV02.Requests
{
	public class ValidateRefreshTokenRequest
	{
        public string  UserId { get; set; }
        public RefreshToken	RefreshToken { get; set; }
    }
}
