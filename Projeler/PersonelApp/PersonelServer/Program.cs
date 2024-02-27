using DefaultCorsPolicyNugetPackage;
using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using PersonelServer.Context;
using System.Net;

var builder = WebApplication.CreateBuilder(args);

//CORS politiasý Cross Origin 

builder.Services.AddDefaultCors();

//builder.Services.AddCors(configuration =>
//{
//    configuration.AddDefaultPolicy(policy =>
//    {
//       // policy.WithMethods("GET","POST").WithHeaders("Value").AllowCredentials().WithOrigins("https://localhost:4200");
//       policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
//    });
//});

builder.Services.AddHealthChecks()
    .AddDbContextCheck<ApplicationDbContext>();
    //.AddSqlServer(builder.Configuration.GetConnectionString("SqlServer") ?? "");

builder.Services.AddHealthChecksUI(options =>
{
    options.AddHealthCheckEndpoint("HealthCheck API", "/healthcheck");
})
  .AddInMemoryStorage();

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

app.UseCors();

app.UseStaticFiles();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapHealthChecksUI(options => options.UIPath = "/dashboard");

app.Run();
