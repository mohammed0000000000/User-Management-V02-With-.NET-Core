﻿using UserManagementV02.Models;
using UserManagementV02.Requests;
using UserManagementV02.Responses;

namespace UserManagementV02.Interfaces
{
	public interface IAuthService
	{
		Task<AuthResponse> RegisterAsync(SignUpRequest request);
		Task<AuthResponse> LoginAsync(SignInRequest request);
		Task<AuthResponse> RefreshTokenAsync(string token);
		Task<bool> RefreshTokenRevokeAsync(string token);
		Task<bool> VerifyEmail(VerifyEmailRequest request);
	}
}
