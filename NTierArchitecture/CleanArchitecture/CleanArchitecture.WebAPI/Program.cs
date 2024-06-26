using CleanArchitecture.Application;
using CleanArchitecture.Application.Features.Vehicles.Commands.CreateVehicle;
using CleanArchitecture.Infrastructure;
using CleanArchitecture.WebAPI.Middlewares;
using DefaultCorsPolicyNugetPackage;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApplication();

builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddDefaultCors();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
if (app.Environment.IsDevelopment() || app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseMiddleware<AutoFluentValidationMiddleware>();

app.UseCors();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
