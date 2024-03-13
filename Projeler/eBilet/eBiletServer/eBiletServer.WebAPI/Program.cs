using eBiletServer.Application;
using eBiletServer.Infrastructure.Services;
using eBiletServer.Persistance;
using eBiletServer.WebAPI.Middleware;
using eBiletServer.WebAPI.Options;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<EmailSettings>(builder.Configuration.GetSection("EmailSettings"));

var serviceProvider = builder.Services.BuildServiceProvider();
var emailSettings = serviceProvider.GetRequiredService<IOptions<EmailSettings>>().Value;

builder.Services
    .AddFluentEmail(emailSettings.From)
    .AddSmtpSender(emailSettings.SMTP, emailSettings.Port);

builder.Services.AddPersistance();
builder.Services.AddApplication();

builder.Services.AddHostedService<SendFailedEmailBackgroundService>();

builder.Services.AddExceptionHandler<ExceptionMiddleware>().AddProblemDetails();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseExceptionHandler();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
