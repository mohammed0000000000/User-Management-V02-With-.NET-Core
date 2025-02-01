using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using UserManagementV02.Exceptions;

namespace UserManagementV02.Filters
{
	public class CustomExceptionFilter : IExceptionFilter
	{
		private readonly ILogger<CustomExceptionFilter> logger;
		public CustomExceptionFilter(ILogger<CustomExceptionFilter> logger) {
			this.logger = logger;
		}
		public void OnException(ExceptionContext context) {
			logger.LogError(context.Exception, "An Exception Occur.\n When Uising Exception Filter");
			var result = new ObjectResult(new {
				error = "Custom Error Occur. Catched By Filter",
				details = context.Exception.Message /// Be cautious about exposing exception details in production
			}) {
				StatusCode = context.Exception switch {
					NotFoundException => StatusCodes.Status404NotFound,
					ValidationException => StatusCodes.Status400BadRequest
				}
			};
			context.Result = result;
			context.ExceptionHandled = true;	// if false handle by global middleware
		}
	}
}
