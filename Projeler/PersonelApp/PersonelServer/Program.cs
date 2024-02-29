using DefaultCorsPolicyNugetPackage;
using FluentValidation;
using FluentValidation.AspNetCore;
using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using PersonelServer.Context;
using PersonelServer.Repositories;
using PersonelServer.Services;
using System.Net;
using System.Reflection;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddScoped<PersonelRepository>();
builder.Services.AddScoped<ProfessionRepository>();
builder.Services.AddScoped<IUnitOfWork>(srv => srv.GetRequiredService<ApplicationDbContext>());

builder.Services.AddScoped<PersonelService>();

builder.Services.AddAutoMapper(typeof(Program).Assembly);

builder.Services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly()).AddFluentValidationAutoValidation();

builder.Services.AddDefaultCors();

builder.Services.AddHealthChecks()
    .AddDbContextCheck<ApplicationDbContext>();

//builder.Services.AddHealthChecksUI(options =>
//{
//    options.AddHealthCheckEndpoint("HealthCheck API", "/healthcheck");
//})
//  .AddInMemoryStorage();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("SqlServer"));
});


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapHealthChecks("healthcheck", new HealthCheckOptions()
{
    ResultStatusCodes =
    {
        [HealthStatus.Healthy] = StatusCodes.Status200OK,
        [HealthStatus.Degraded] = StatusCodes.Status400BadRequest,
        [HealthStatus.Unhealthy] = StatusCodes.Status500InternalServerError,
    },
    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
});

app.Use(async (context, next) =>
{
    try
    {
        await next(context);
    }
    catch (Exception ex)
    {
        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
        context.Response.ContentType = "application/json";

        var data = new
        {
            Message = ex.Message
        };

        var errorResponse = JsonSerializer.Serialize(data);

        await context.Response.WriteAsync(errorResponse);
    }
});

app.UseCors();

app.UseStaticFiles();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapHealthChecksUI(options => options.UIPath = "/dashboard");

app.Run();
