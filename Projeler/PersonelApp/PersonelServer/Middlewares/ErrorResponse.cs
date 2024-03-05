
using Newtonsoft.Json;

namespace PersonelServer.Middlewares;

public sealed class ErrorResponse
{
    public ErrorResponse(string message)
    {
        Message = message;
    }
    public string Message { get; init; }

    public override string ToString()
    {
        //return JsonSerializer.Serialize(this);
        return JsonConvert.SerializeObject(this);
    }
}