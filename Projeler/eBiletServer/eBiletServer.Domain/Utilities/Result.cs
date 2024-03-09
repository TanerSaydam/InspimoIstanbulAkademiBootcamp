namespace eBiletServer.Domain.Utilities;
public class Result<T>
{
    public Result(T value)
    {
        Value = value;
    }

    public Result(HashSet<string> errorMessages)
    {
        ErrorMessages = errorMessages;
        StatusCode = 500;
    }

    public Result(int statusCode, HashSet<string> errorMessages)
    {
        ErrorMessages = errorMessages;
        StatusCode = statusCode;
    }

    public Result(int statusCode, string errorMessage)
    {
        ErrorMessages = new() { errorMessage };
        StatusCode = statusCode;
    }
    public T? Value { get; set; }
    public HashSet<string>? ErrorMessages { get; set; }
    public int StatusCode { get; set; } = 200;
    
    public static Result<T> Succeed(T value)
    {
        return new Result<T>(value);
    }  
    public static Result<T> Failure(HashSet<string> errorMessages)
    {
        return new Result<T>(errorMessages);
    }

    public static Result<T> Failure(int statusCode, HashSet<string> errorMessages)
    {
        return new Result<T>(statusCode, errorMessages);
    }

    public static Result<T> Failure(int statusCode, string errorMessage)
    {
        return new Result<T>(statusCode, errorMessage);
    }

    public static Result<T> Failure(string errorMessage)
    {
        return new Result<T>(500, errorMessage);
    }

    public static implicit operator Result<T>(T value)
    {
        return new(value);
    }

    public static implicit operator Result<T>((int statusCode, string errorMessage) parameter)
    {
        return new(parameter.statusCode, parameter.errorMessage);
    }

    public static implicit operator Result<T>((int statusCode, HashSet<string> errorMessages) parameter)
    {
        return new(parameter.statusCode, parameter.errorMessages);
    }
}