using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;
using UserManagementV02.Interfaces;
using UserManagementV02.Requests;
using UserManagementV02.Responses;
using UserManagementV02.Settings;

namespace UserManagementV02.Services
{
	public class MailServices : IMailService
	{
		private readonly MailSettings _mailSettings;
		public MailServices(IOptions<MailSettings> mailSettings) {
			_mailSettings = mailSettings.Value;
		}
		public async Task<SendEmailResponse> SendEmail(MailRequest mailRequest) {
			var email = new MimeMessage();
			email.Sender = MailboxAddress.Parse(_mailSettings.SenderEmail);
			email.To.Add(MailboxAddress.Parse(mailRequest.ToEmail));
			email.Subject = mailRequest.Subject;

			var builder = new BodyBuilder();
			if (mailRequest.Attachments != null) {
				byte[] fileBytes;
				foreach (var file in mailRequest.Attachments) {
					if (file.Length > 0) {
						using (var ms = new MemoryStream()) {
							file.CopyTo(ms);
							fileBytes = ms.ToArray();
						}
						builder.Attachments.Add(file.FileName, fileBytes, ContentType.Parse(file.ContentType));
					}
				}
			}
			builder.HtmlBody = mailRequest.Body;
			email.Body = builder.ToMessageBody();

			using var stmp = new SmtpClient();
			await stmp.ConnectAsync(_mailSettings.SmtpServer, _mailSettings.SmtpPort, SecureSocketOptions.StartTls);
			await stmp.AuthenticateAsync(_mailSettings.SenderEmail, _mailSettings.Password);
			await stmp.SendAsync(email);
			stmp.Disconnect(true);
			return new SendEmailResponse() {
				Success = true,
				Message = "Message Send Succefully"
			};
		}
	}
}
