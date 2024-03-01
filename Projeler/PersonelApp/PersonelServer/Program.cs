using DefaultCorsPolicyNugetPackage;
using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using PersonelServer.Extensions;
using PersonelServer.Middlewares;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDependencyInjection(builder.Configuration);
builder.Services.AddDefaultCors();
//builder.Services.AddHealthChecksDI();
builder.Services.AddExceptionHandler<ExceptionHandler2>();
builder.Services.AddProblemDetails();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.MapHealthChecks("healthcheck", new HealthCheckOptions()
//{
//    ResultStatusCodes =
//    {
//        [HealthStatus.Healthy] = StatusCodes.Status200OK,
//        [HealthStatus.Degraded] = StatusCodes.Status400BadRequest,
//        [HealthStatus.Unhealthy] = StatusCodes.Status500InternalServerError,
//    },
//    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
//});

app.UseExtensions();

app.UseCors();

app.UseStaticFiles();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

//app.MapHealthChecksUI(options => options.UIPath = "/dashboard");

app.Run();
