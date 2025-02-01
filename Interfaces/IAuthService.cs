using UserManagementV02.Models;
using UserManagementV02.Requests;

namespace UserManagementV02.Interfaces
{
	public interface IAuthService
	{
		Task<AuthModel> RegisterAsync(SignUpRequest request);
		Task<AuthModel> LoginAsync(SignInRequest request);
		Task<AuthModel> RefreshTokenAsync(string token);
		Task<bool> RefreshTokenRevokeAsync(string token);
		Task<bool> VerifyEmail(VerifyEmailRequest request);
	}
}
