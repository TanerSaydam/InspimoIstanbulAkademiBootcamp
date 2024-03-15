using eBiletServer.Application.Services;
using eBiletServer.Infrastructure.Authentication;
using eBiletServer.Infrastructure.Options;
using eBiletServer.Infrastructure.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Net;
using System.Text;

namespace eBiletServer.Infrastructure;
public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddHostedService<SendFailedEmailBackgroundService>();

        services.AddScoped<IJwtProvider, JwtProvider>();
        services.Configure<JwtOptions>(configuration.GetSection("Jwt"));
        services.ConfigureOptions<JwtBearerOptionsSetup>();

        services.AddAuthentication().AddJwtBearer();
        services.AddAuthorizationBuilder();

        //var serviceProvider = services.BuildServiceProvider();
        //var jwtOptions = serviceProvider.GetRequiredService<IOptions<JwtOptions>>().Value;

        //SymmetricSecurityKey securityKey = new(Encoding.UTF8.GetBytes(jwtOptions.SecretKey));



        return services;
    }
}
