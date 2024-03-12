using eBiletServer.Application;
using eBiletServer.Persistance;
using eBiletServer.WebAPI.Middleware;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddExceptionHandler<ExceptionMiddleware>().AddProblemDetails();

builder.Services.AddPersistance();
builder.Services.AddApplication();

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
