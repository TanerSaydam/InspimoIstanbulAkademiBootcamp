using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace PersonelServer.Middlewares;

public static class ExtensionsMiddleware
{
    public static IApplicationBuilder UseExtensions(this IApplicationBuilder app)
    {
        //app.UseMiddleware<ExceptionHandler>();
        app.UseExceptionHandler();
        return app;
    }
}
