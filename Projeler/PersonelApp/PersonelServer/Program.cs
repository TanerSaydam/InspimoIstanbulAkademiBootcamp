using DefaultCorsPolicyNugetPackage;
using Microsoft.IdentityModel.Tokens;
using PersonelServer.Extensions;
using PersonelServer.Middlewares;
using PersonelServer.Options;
using PersonelServer.Utilities;
using System.Security.Claims;
using System.Text;

var builder = WebApplication.CreateBuilder(args);



builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();


builder.Services.AddDependencyInjection(builder.Configuration);
builder.Services.AddAuthenticationDI();
builder.Services.CreateServiceTool();


builder.Services.AddDefaultCors();
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

app.UseExtensions();

app.UseCors();

app.UseStaticFiles();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers()
    .RequireAuthorization(policy =>
    {
        policy.RequireClaim(ClaimTypes.NameIdentifier);
        policy.AddAuthenticationSchemes("Bearer");
    });

app.Run();
