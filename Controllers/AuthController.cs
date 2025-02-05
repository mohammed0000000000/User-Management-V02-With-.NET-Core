using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserManagementV02.Interfaces;
using UserManagementV02.Requests;

namespace UserManagementV02.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AuthController : ControllerBase
	{
		private readonly IAuthService authService;
        public AuthController(IAuthService authService)
        {
			this.authService = authService;
        }
        [HttpPost("SignUp")]
		public async Task<IActionResult> signUp(SignUpRequest request){
			if (!ModelState.IsValid){
				var erros = ModelState.Where(x => x.Value.Errors.Count > 0).ToDictionary(kvp => kvp.Key, kvp => kvp.Value.Errors.Select)
				return BadRequest(ModelState);
			}
			var response = await authService.RegisterAsync(request);
			if(!response.Success)
			return UnprocessableEntity()
		}
	}
}
