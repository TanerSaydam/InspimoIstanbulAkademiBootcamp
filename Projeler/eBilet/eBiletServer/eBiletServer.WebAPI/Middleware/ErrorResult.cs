using System.Text.Json;

namespace eBiletServer.WebAPI.Middleware;

public sealed class ErrorResult
{
    public string Message { get; init; }

    public ErrorResult(string message)
    {
        Message = message;
    }

    public override string ToString()
    {
        return JsonSerializer.Serialize(this);
    }
}