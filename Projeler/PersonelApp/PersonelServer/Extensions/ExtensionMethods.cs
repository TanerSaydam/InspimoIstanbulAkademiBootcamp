using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using PersonelServer.Context;
using PersonelServer.Repositories;
using PersonelServer.Services;
using System.Reflection;

namespace PersonelServer.Extensions;

public static class ExtensionMethods
{    
    public static IServiceCollection AddDependencyInjection(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("SqlServer"));
        });

        //services.AddTransient<ExceptionHandler>();
        services.AddScoped<PersonelRepository>();
        services.AddScoped<ProfessionRepository>();
        services.AddScoped<IUnitOfWork>(srv => srv.GetRequiredService<ApplicationDbContext>());

        services.AddScoped<PersonelService>();

        services.AddAutoMapper(typeof(Program).Assembly);

        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly()).AddFluentValidationAutoValidation();              

        return services;

    }

    public static IServiceCollection AddHealthChecksDI(this IServiceCollection services)
    {
        services.AddHealthChecks();
            //.AddDbContextCheck<ApplicationDbContext>();

        services.AddHealthChecksUI(options =>
        {
            options.AddHealthCheckEndpoint("HealthCheck API", "/healthcheck");
        })
          .AddInMemoryStorage();

        return services;
    }
}
