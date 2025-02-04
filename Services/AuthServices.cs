using Microsoft.AspNetCore.Identity;
using UserManagementV02.Interfaces;
using UserManagementV02.Models;
using UserManagementV02.Requests;
using UserManagementV02.Responses;

namespace UserManagementV02.Services
{
	public class AuthServices : IAuthService
	{
		private readonly UserManager<ApplicationUser> userManager;
		public AuthServices(UserManager<ApplicationUser> userManager) {
			this.userManager = userManager;
		}
		public async Task<AuthResponse> LoginAsync(SignInRequest request) {

			var user = await userManager.FindByEmailAsync(request.Email);
			if ((user is null) || (await userManager.CheckPasswordAsync(user, request.Password) == false))
			return new AuthResponse() { 
				Success = false,
				Message = "InValid Credentials"
			};

			if(await )
			
		}

		public Task<AuthResponse> RefreshTokenAsync(string token) {
			throw new NotImplementedException();
		}

		public Task<bool> RefreshTokenRevokeAsync(string token) {
			throw new NotImplementedException();
		}

		public Task<AuthResponse> RegisterAsync(SignUpRequest request) {
			throw new NotImplementedException();
		}

		public Task<bool> VerifyEmail(VerifyEmailRequest request) {
			throw new NotImplementedException();
		}
	}
}
