using DependencyInjection.WebAPI.Controllers;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddScoped<IClass1, Class2>();

builder.Services.AddScoped<Student>();
builder.Services.AddScoped<Class1>();
builder.Services.AddScoped<Class2>();
builder.Services.AddTransient<Class2>();
builder.Services.AddSingleton<Class2>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
