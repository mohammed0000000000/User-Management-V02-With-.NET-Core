using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserManagementV02.Exceptions;
using UserManagementV02.Filters;
using UserManagementV02.Interfaces;

namespace UserManagementV02.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AdminController : ControllerBase
	{
		private readonly IAdminService adminService;

		public AdminController(IAdminService adminService) {
			this.adminService = adminService;
		}
		[TypeFilter(typeof(CustomExceptionFilter))]
		[HttpGet("Test")]
		public IActionResult test() {
			try {
				adminService.testSerivce();
				return Ok();
			} catch (Exception) {
				throw;
			}
		}
	}
}