namespace UserManagementV02.Exceptions
{
    public class UnprocessableEntityException : BaseException
    {
        public UnprocessableEntityException(string message) : base(message) { }
        public UnprocessableEntityException(string message, Dictionary<string, string> errors) : base(message, errors) {}
    }
}
