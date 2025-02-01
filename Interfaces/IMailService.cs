using UserManagementV02.Requests;

namespace UserManagementV02.Interfaces
{
	public interface IMailService
	{
		Task<bool> SendEmail(MailRequest request);
	}
}
