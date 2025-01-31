namespace UserManagementV02.Interfaces
{
	public interface IAuthService
	{
		Task<AuthModel> RegisterAsync(registerDto registerDto);
		Task<AuthModel> LoginAsync(loginDto loginDto);
		Task<AuthModel> RefreshTokenAsync(string token);
		Task<bool> RefreshTokenRevokeAsync(string token);
		Task<bool> VerifyEmail(verifyEmailDto model)
	}
}
