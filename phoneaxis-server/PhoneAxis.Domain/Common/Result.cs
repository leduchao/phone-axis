using System.Net;

namespace PhoneAxis.Domain.Common;

public sealed class Result<T>(bool isSuccess, int statusCode)
{
    public bool IsSuccess { get; set; } = isSuccess;

    public int StatusCode { get; set; } = statusCode;

    public string? Message { get; set; }

    public string[] Errors { get; set; } = [];

    public T? Data { get; set; }

    public static Result<T> Success(T? data, string? message, int statusCode = (int)HttpStatusCode.OK)
    {
        return new(true, statusCode)
        {
            Message = message,
            Data = data,
        };
    }

    public static Result<T> Fail(string[] errors, int statusCode = (int)HttpStatusCode.BadRequest)
    {
        return new(false, statusCode)
        {
            Errors = errors,
        };
    }
}

public sealed class Result(bool isSuccess, int statusCode)
{
    public bool IsSuccess { get; set; } = isSuccess;

    public int StatusCode { get; set; } = statusCode;

    public string? Message { get; set; }

    public string[] Errors { get; set; } = [];

    public static Result Success(string? message, int statusCode = (int)HttpStatusCode.OK)
    {
        return new(true, statusCode)
        {
            Message = message,
        };
    }

    public static Result Fail(string[] errors, int statusCode = (int)HttpStatusCode.BadRequest)
    {
        return new(false, statusCode)
        {
            Errors = errors,
        };
    }
}
