using Microsoft.AspNetCore.Mvc;
using UserManagementV02.Exceptions;

namespace UserManagementV02.Middelwares
{
	public class ExceptionMiddleware
	{
		private readonly RequestDelegate next;
		private readonly ILogger<ExceptionMiddleware> logger;

		public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger) {
			this.next = next;
			this.logger = logger;
		}

		public async Task InvokeAsync(HttpContext context) {
			try {
				await next(context);
			} catch (Exception ex) {
				logger.LogError(ex, "An unhandle Exception Error in Exception Middleware in InvokedAsync Function");
				await HandleExceptionAsync(context, ex);
			}
		}
		
		private static async Task HandleExceptionAsync(HttpContext context, Exception exception){
			context.Response.ContentType = "application/json";
			var statusCode = exception switch {
				NotFoundException => StatusCodes.Status404NotFound,
				ValidationException => StatusCodes.Status400BadRequest,
				_ => StatusCodes.Status500InternalServerError
			};
			context.Response.StatusCode = statusCode;
			var problemDetails = new ProblemDetails {
				Title = "An Error Occurred While Processing Your Request",
				Status = statusCode,
				Detail = exception.Message,
				Instance = context.Request.Path
			};
			await context.Response.WriteAsJsonAsync(problemDetails);
		}
	}
}
