using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.CodeAnalysis.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using PersonelServer.Context;
using PersonelServer.Options;
using PersonelServer.Repositories;
using PersonelServer.Services;
using System.Reflection;
using System.Text;

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
        services.AddScoped<JwtProvider>();
        services.AddScoped<UserRepository>();
        services.AddScoped<UserService>();

        services.AddScoped<PersonelService>();

        services.AddAutoMapper(typeof(Program).Assembly);

        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly()).AddFluentValidationAutoValidation();              

        return services;

    }

    public static IServiceCollection AddHealthChecksDI(this IServiceCollection services)
    {
        //services.AddHealthChecks();
        //    //.AddDbContextCheck<ApplicationDbContext>();

        //services.AddHealthChecksUI(options =>
        //{
        //    options.AddHealthCheckEndpoint("HealthCheck API", "/healthcheck");
        //})
        //  .AddInMemoryStorage();

        return services;
    }

    public static IServiceCollection AddAuthenticationDI(this IServiceCollection services)
    {
        //var srv = services.BuildServiceProvider();
        //var options = srv.GetRequiredService<IOptions<JwtOptions>>().Value;

        //services.Configure<JwtOptions>(builder.Configuration.GetSection("Jwt"));
        services.ConfigureOptions<JwtOptionsSetup>();
        services.ConfigureOptions<JwtValidationParametersOptions>();

        services.AddAuthentication().AddJwtBearer();
        services.AddAuthorizationBuilder();

        return services;
    }
}
