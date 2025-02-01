using System.Text.Json.Serialization;

namespace UserManagementV02.Responses
{
	public class SendEmailResponse : BaseResponse
	{
		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Message { get; set; }
    }
}
