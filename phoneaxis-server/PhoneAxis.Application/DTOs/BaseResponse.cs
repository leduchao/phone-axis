namespace PhoneAxis.Application.DTOs;

public class BaseResponse(int statusCode, string message = "")
{
    public int StatusCode { get; set; } = statusCode;

    public string Message { get; set; } = message;

    public string[] Errors { get; set; } = [];
}
