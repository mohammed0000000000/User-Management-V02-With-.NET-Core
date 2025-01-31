using System.ComponentModel.DataAnnotations;

namespace UserManagementV02.Requests
{
	public class MailRequest
	{
		[Required]
		public string ToEmail { get; set; }
		[Required]
		public string Subject { get; set; }
		public string? Body { get; set; }
		public List<IFormFile>? Attachments { get; set; } = new List<IFormFile> { };
	}
}
