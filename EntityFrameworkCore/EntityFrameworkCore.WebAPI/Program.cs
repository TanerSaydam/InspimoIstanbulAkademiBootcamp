using EntityFrameworkCore.WebAPI.Context;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

//builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
builder.Services.AddAutoMapper(typeof(ApplicationDbContext).Assembly);

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{//scope
    options.UseSqlServer(builder.Configuration.GetConnectionString("SqlServer"));
}); //lambda expressions

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
