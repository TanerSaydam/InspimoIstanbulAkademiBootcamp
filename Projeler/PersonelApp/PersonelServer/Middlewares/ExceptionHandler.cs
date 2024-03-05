using k8s.KubeConfigModels;
using Microsoft.AspNetCore.Diagnostics;
using System.Text.Json;

namespace PersonelServer.Middlewares;

public class ExceptionHandler : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
		try
		{
			await next(context);
		}
		catch (Exception ex)
		{
			context.Response.StatusCode = 500;
			context.Response.ContentType = "application/json";
			await context.Response.WriteAsync(new ErrorResponse(ex.Message).ToString());
		}
    }
}


public class ExceptionHandler2 : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(HttpContext context, Exception ex, CancellationToken cancellationToken)
    {
        context.Response.StatusCode = 500;
		if(ex.GetType() == typeof(UnauthorizedAccessException)){
			context.Response.StatusCode = 401;
		}
        context.Response.ContentType = "application/json";

        await context.Response.WriteAsync(new ErrorResponse(ex.Message).ToString());

		return true;
    }
}
