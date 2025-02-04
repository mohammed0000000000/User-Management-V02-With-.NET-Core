using UserManagementV02.Models;
using UserManagementV02.Requests;
using UserManagementV02.Responses;

namespace UserManagementV02.Interfaces
{
	public interface ITokenSerivce
	{
		Task<Tuple<string, RefreshToken>> GenerateTokenAsync(ApplicationUser user);
		Task<AuthResponse> RefreshTokenAsync(string token);
		Task<bool> RefreshTokenRevokeAsync(string token);
		//Task<bool> ValidateRefreshTokenAsync(ValidateRefreshTokenRequest request);
		//Task<bool> RemoveRefreshTokenAsync(ApplicationUser user);
	}
}
