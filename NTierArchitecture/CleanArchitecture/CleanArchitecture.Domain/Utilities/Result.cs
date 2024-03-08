namespace CleanArchitecture.Domain.Utilities;
public sealed class Result<T>
{
    public T? Value { get; set; }
    public List<string>? Errors { get; set; }
    public int StatuCode { get; set; } = 200;

    public Result()
    {
        
    }

    public Result(T value)
    {
        Value = value;
    }

    public Result(int statusCode, string errorMessage)
    {
        StatuCode = statusCode;
        Errors = new List<string>() { errorMessage};
    }

    public static Result<T> Failure(int statusCode, string errorMessage)
    {
        return new(statusCode, errorMessage);
    }

    public static Result<T> Failure(string errorMessage)
    {
        return new(500, errorMessage);
    }

    public static Result<T> Succeed(T value)
    {
        return new(value);
    }

    public static implicit operator Result<T>(T value)
    {
        return new(value);
    }
}
