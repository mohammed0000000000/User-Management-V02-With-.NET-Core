using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using UserManagementV02.Helpers;
using UserManagementV02.Interfaces;
using UserManagementV02.Models;
using UserManagementV02.Requests;
using UserManagementV02.Responses;

namespace UserManagementV02.Services
{
	public class TokenServices:ITokenSerivce
	{
		private readonly UserManager<ApplicationUser> userManager;
		private readonly TokenHelpers tokenHelpers;
		public TokenServices(TokenHelpers tokenHelpers, UserManager<ApplicationUser> userManager) { 
			this.userManager = userManager;
			this.tokenHelpers = tokenHelpers;
		}

		public async Task<Tuple<string, RefreshToken>> GenerateTokenAsync(ApplicationUser user) {
			var accessToken = await tokenHelpers.GenerateAccessTokenAsync(user);
			var refreshToken = user.RefreshTokens.FirstOrDefault(x => x.isActive);
			if (refreshToken is null) {
				refreshToken = tokenHelpers.GenerateRefreshToken();
				user.RefreshTokens.Add(refreshToken);
				await userManager.UpdateAsync(user);
			}
			return Tuple.Create(accessToken, refreshToken);
		}
		public async Task<AuthResponse> RefreshTokenAsync(string token) {
				var user = await userManager.Users.SingleOrDefaultAsync(user => user.RefreshTokens.Any(x => x.Token == token && x.isActive));
				if (user is null)
					return new AuthResponse() {
						Success = false,
						Error = "InValid Token",
						ErrorCode = "R02"
					};
				var refreshToken = user.RefreshTokens.First(x => x.Token == token);
				refreshToken.RevokedOn = DateTime.UtcNow;

				var newRefreshToken = tokenHelpers.GenerateRefreshToken();
				user.RefreshTokens.Add(refreshToken);
				await userManager.UpdateAsync(user);

				var accessToken = await tokenHelpers.GenerateAccessTokenAsync(user);

				return new AuthResponse() {
					AccessToken = accessToken,
					RefreshToken = newRefreshToken.Token,
					RefreshTokenExpireOn = newRefreshToken.ExpiresOn,
				};
			
		}
		public Task<bool> RemoveRefreshTokenAsync(ApplicationUser user) {
			throw new NotImplementedException();
		}

		public Task<bool> ValidateRefreshTokenAsync(ValidateRefreshTokenRequest request) {
			throw new NotImplementedException();
		}
	}
}
