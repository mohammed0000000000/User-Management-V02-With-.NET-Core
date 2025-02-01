using UserManagementV02.Requests;
using UserManagementV02.Responses;

namespace UserManagementV02.Interfaces
{
	public interface IMailService
	{
		Task<SendEmailResponse> SendEmail(MailRequest request);
	}
}
