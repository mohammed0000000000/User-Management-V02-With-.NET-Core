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
				message = context.Exception.Message,
				errors = context.Exception is BaseException ex ? ex.Errors : null
			}) {
				StatusCode = context.Exception switch {
					NotFoundException => StatusCodes.Status404NotFound,
					BadRequestException => StatusCodes.Status400BadRequest,
					UnprocessableEntityException => StatusCodes.Status422UnprocessableEntity,
				},
			};
			context.Result = result;
			context.ExceptionHandled = true;	// if false handle by global middleware
		}
	}
}
