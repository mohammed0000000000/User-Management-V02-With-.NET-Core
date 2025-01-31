using System.Text.Json.Serialization;

namespace UserManagementV02.Responses
{
	public abstract class BaseResponse
	{
		[JsonIgnore()]
		//public bool Success { get; set; }
		public bool Success => string.IsNullOrEmpty(Error);

		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
		public string? ErrorCode { get; set; }

		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
		public string? Error { get; set; }
	}
}
