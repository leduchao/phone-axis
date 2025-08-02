namespace PhoneAxis.Domain.Common;

public sealed class Result<TData>
{
    private readonly bool _isSuccess;

    public bool Succeeded => _isSuccess;

    public Error[] Errors { get; init; }

    public TData? Data { get; set; }

    private Result(bool isSuccess, Error[] errors)
    {
        if ((isSuccess && errors.Length > 0) || (!isSuccess && errors.Length == 0))
        {
            throw new ArgumentException("Invalid errors", nameof(errors));
        }

        _isSuccess = isSuccess;
        Errors = errors;
    }

    public static Result<TData> Success(TData? data) => new(true, []) { Data = data };

    public static Result<TData> Failure(Error[] errors) => new(false, errors);
}

public sealed class Result
{
    private readonly bool _isSuccess;

    public bool Succeeded => _isSuccess;

    public Error[] Errors { get; init; }

    private Result(bool isSuccess, Error[] errors)
    {
        if ((isSuccess && errors.Length > 0) || (!isSuccess && errors.Length == 0))
        {
            throw new ArgumentException("Invalid errors", nameof(errors));
        }

        _isSuccess = isSuccess;
        Errors = errors;
    }

    public static Result Success() => new(true, []);

    public static Result Failure(Error[] errors) => new(false, errors);
}
