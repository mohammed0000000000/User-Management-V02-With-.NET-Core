using UserManagementV02.Interfaces;
using UserManagementV02.Requests;

namespace UserManagementV02.Services
{
	public class MailServices : IMailService
	{
		public async Task<bool> SendEmail(MailRequest request) {
			return true;
		}
	}
}
