namespace UserManagementV02.Exceptions
{
	public  class BaseException: Exception
	{
		public Dictionary<string, string> Errors { get; set; }
        //public Dictionary<string,string> Errors { get; set; }
        public BaseException(string message) : base(message) { }
        public BaseException(string message, Dictionary<string, string> errors):base(message)
        {
            Errors = errors ?? new Dictionary<string, string>();   
        }
    }
}
