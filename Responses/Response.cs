using System.Text.Json.Serialization;

namespace UserManagementV02.Responses
{
	public class Response <T> : BaseResponse
	{
		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
		public T ?Data { get; set; }

		public static Response<T> Success(T data) => new Response<T> { Data = data };
		public static Response<T> Fail(string errorCode, string error) => new Response<T> { ErrorCode = errorCode, Error = error };
	}
}
