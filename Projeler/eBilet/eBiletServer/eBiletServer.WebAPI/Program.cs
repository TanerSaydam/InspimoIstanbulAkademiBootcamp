using DefaultCorsPolicyNugetPackage;
using eBiletServer.Application;
using eBiletServer.Infrastructure;
using eBiletServer.Infrastructure.Services;
using eBiletServer.Persistance;
using eBiletServer.Prestantion.Controllers;
using eBiletServer.WebAPI.Middleware;
using eBiletServer.WebAPI.Options;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<EmailSettings>(builder.Configuration.GetSection("EmailSettings"));

builder.Services.AddDefaultCors();

var serviceProvider = builder.Services.BuildServiceProvider();
var emailSettings = serviceProvider.GetRequiredService<IOptions<EmailSettings>>().Value;

builder.Services
    .AddFluentEmail(emailSettings.From)
    .AddSmtpSender(emailSettings.SMTP, emailSettings.Port);

builder.Services.AddPersistance();
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddApplication();

builder.Services.AddExceptionHandler<ExceptionMiddleware>().AddProblemDetails();

builder.Services.AddControllers().AddApplicationPart(typeof(AuthController).Assembly);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors();

app.UseExceptionHandler();

app.UseHttpsRedirection();

app.MapControllers().RequireAuthorization(policy =>
{
    policy.RequireClaim("UserId");
    policy.AddAuthenticationSchemes("Bearer");
});

app.Run();
