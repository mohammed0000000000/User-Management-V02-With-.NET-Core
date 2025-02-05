using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Routing;
using UserManagementV02.Interfaces;
using UserManagementV02.Models;
using UserManagementV02.Requests;
using UserManagementV02.Responses;

namespace UserManagementV02.Services
{
	public class AuthServices : IAuthService
	{
		private readonly UserManager<ApplicationUser> userManager;
		private readonly ITokenSerivce tokenSerivce;
		private readonly IMailService mailService;
		private readonly IUrlHelper urlHelperFactory;
		public AuthServices(UserManager<ApplicationUser> userManager, ITokenSerivce tokenSerivce, IMailService mailService, IUrlHelperFactory urlHelperFactory,
		IActionContextAccessor actionContextAccessor) {
			this.userManager = userManager;
			this.tokenSerivce = tokenSerivce;
			this.mailService = mailService;
			this.urlHelperFactory = urlHelperFactory.GetUrlHelper(actionContextAccessor.ActionContext);
		}
		public async Task<AuthResponse> LoginAsync(SignInRequest request) {

			var user = await userManager.FindByEmailAsync(request.Email);
			if (user is null)
				return new AuthResponse() {
					Success = false,
					Error = "InValid Credentails",
					ErrorCode = "L01"
				};
			if (user.IsAccountDisabled)
				return new AuthResponse() {
					Success = false,
					ErrorCode = "L02",
					Error = "Account Not Avaliable"
				};
			if (!user.isVerify)
				return new AuthResponse() {
					Success = false,
					Error = "Your Account Not Verify, Please Check  your mail",
					ErrorCode = "L03"
				};
			if (await userManager.CheckPasswordAsync(user, request.Password) == false)
				return new AuthResponse() {
					Success = false,
					Error = "InValid Credentails",
					ErrorCode = "L04"
				};

			var token = await tokenSerivce.GenerateTokenAsync(user);
			return new AuthResponse() {
				Success = true,
				UserName = user.UserName,
				AccessToken = token.Item1,
				RefreshToken = token.Item2.Token,
				RefreshTokenExpireOn = token.Item2.ExpiresOn
			};
		}

		public async Task<AuthResponse> RegisterAsync(SignUpRequest request) {
			// check if email already exist
			var checkUserExist = await userManager.FindByEmailAsync(request.Email);
			if (checkUserExist is not null)
				return new AuthResponse() {
					Success = false,
					Error = "Email Already Exist",
					ErrorCode = "R01"
				};
			// create user 
			var user = new ApplicationUser() {
				Email = request.Email,
				FirstName = request.FirstName,
				LastName = request.LastName
			};
			var result = await userManager.CreateAsync(user, request.Password);

			if (!result.Succeeded)
				return new AuthResponse() {
					Success = false,
					Error = "Enter Server Error, when Register",
					ErrorCode = "R02"
				};
			// Send verifacation mail
			var token = await userManager.GenerateEmailConfirmationTokenAsync(user);
			var confirmUrl = urlHelperFactory.Action("ConfirmEmail", "Auth", new { userId = user.Id, token });
			var mailRequest = new MailRequest() {
				ToEmail = request.Email,
				Subject = "Confirm Your Email",
				Body = $"Registration Successful! Welcome to [Your Application Name]. Please Confirm your account by click on this email :{confirmUrl}"
			};
			var sendEmail = await mailService.SendEmail(mailRequest);
			if (!sendEmail.Success)
				return new AuthResponse() {
					Success = false,
					Error = "Enter Server Error, when Sending Confirm Email",
					ErrorCode = "R03"
				};
			return new AuthResponse() {
				Success = true,
			};
		}

		public Task<bool> VerifyEmail(VerifyEmailRequest request) {
			throw new NotImplementedException();
		}
	}
}
