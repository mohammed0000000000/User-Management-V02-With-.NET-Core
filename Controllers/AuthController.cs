using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserManagementV02.Exceptions;
using UserManagementV02.Interfaces;
using UserManagementV02.Requests;

namespace UserManagementV02.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AuthController : ControllerBase
	{
		private readonly IAuthService authService;
		public AuthController(IAuthService authService) {
			this.authService = authService;
		}
		[HttpPost("SignUp")]
		public async Task<IActionResult> signUp(SignUpRequest request) {
			if (!ModelState.IsValid) {
				var errors = ModelState
				.Where(x => x.Value?.Errors.Count > 0)
				.ToDictionary(kvp => kvp.Key,
				kvp => kvp.Value?.Errors
				.Select(e => e.ErrorMessage)
				.ToString() ?? string.Empty
				 );
				throw new BadRequestException("Validation Error", errors);
			}

			var response = await authService.RegisterAsync(request);
			if (!response.Success) {
				throw new UnprocessableEntityException("Error Occure During Register Proccess",
				new Dictionary<string, string> {
					{"error", response.Error ?? "Unkown Error" },
					{ "erorrCode",  response.ErrorCode ?? "UNKOWN" }
				});
			}
			return Ok(response);
		}
	}
}
