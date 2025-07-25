using PhoneAxis.Domain.Enums;

namespace PhoneAxis.Domain.Common;

public sealed class Result<T>(bool isSuccess)
{
    public bool IsSuccess { get; set; } = isSuccess;

    public T? Data { get; set; }

    public string? SuccessMessage { get; set; }

    public ErrorCode? ErrorCode { get; set; }

    public string[] ErrorMessages { get; set; } = [];

    public static Result<T> Success(T? data, string? successMessage)
    {
        return new(true)
        {
            Data = data,
            SuccessMessage = successMessage
        };
    }

    public static Result<T> Fail(ErrorCode errorCode, string[] errorMessages)
    {
        return new(false)
        {
            ErrorCode = errorCode,
            ErrorMessages = errorMessages
        };
    }
}

public sealed class Result(bool isSuccess)
{
    public bool IsSuccess { get; set; } = isSuccess;

    public ErrorCode? ErrorCode { get; set; }

    public string? SuccessMessage { get; set; }

    public string[] ErrorMessages { get; set; } = [];

    public static Result Success(string? successMessage)
    {
        return new(true)
        {
            SuccessMessage = successMessage,
        };
    }

    public static Result Fail(ErrorCode errorCode, string[] errorMessages)
    {
        return new(false)
        {
            ErrorCode = errorCode,
            ErrorMessages = errorMessages
        };
    }
}
