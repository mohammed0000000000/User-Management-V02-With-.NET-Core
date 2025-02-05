namespace UserManagementV02.Exceptions
{
	public class BadRequestException:BaseException
	{
        public BadRequestException(string message):base(message){}
        public BadRequestException(string message, Dictionary<string, string[]> errors) : base(message, errors) { }
    }
}
