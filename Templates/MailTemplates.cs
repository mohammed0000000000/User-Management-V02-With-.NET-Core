namespace UserManagementV02.Templates
{
	public static class MailTemplates
	{
		public static  string EmailConfirmTemplate(string ApplicationName, string UserName, string ConfirmationLink) {
			return $@"
            <html>
                <body>
                    <h2>Welcome to {ApplicationName}!</h2>
                    <p>Hello {UserName},</p>
                    <p>Thank you for registering. Please verify your email by clicking the link below:</p>
                    <p><a href='{ConfirmationLink}'>Verify Email</a></p>
                    <p>If you didn't request this, please ignore this email.</p>
                    <p>Best regards,<br>{ApplicationName} Team</p>
                </body>
            </html>";
		}
	}
}
