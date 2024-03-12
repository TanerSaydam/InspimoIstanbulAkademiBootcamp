using FluentValidation;
using Microsoft.AspNetCore.Diagnostics;

namespace eBiletServer.WebAPI.Middleware;

public sealed class ExceptionMiddleware : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
    {
        httpContext.Response.StatusCode = 500;
        httpContext.Response.ContentType = "application/json";

        if (exception.GetType() == typeof(ValidationException))
        {
            httpContext.Response.StatusCode = 409;
        }

        string error = new ErrorResult(exception.Message).ToString();
        await httpContext.Response.WriteAsync(error, cancellationToken);             

        return true;
    }
}
