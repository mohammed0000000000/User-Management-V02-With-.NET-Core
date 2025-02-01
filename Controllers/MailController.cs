using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserManagementV02.Interfaces;
using UserManagementV02.Requests;

namespace UserManagementV02.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class MailController : ControllerBase
	{
		private readonly IMailService mailService;

		public MailController(IMailService _mailService) {
			mailService = _mailService;
		}

		[HttpPost("SendEmail")]
		public async Task<IActionResult> sendEmail(MailRequest request) {
			var response = await mailService.SendEmail(request);
			if (response is null) {
				throw new Exception("Error when Sending Message.");
			}
			return Ok(response);
		}
	}
}
