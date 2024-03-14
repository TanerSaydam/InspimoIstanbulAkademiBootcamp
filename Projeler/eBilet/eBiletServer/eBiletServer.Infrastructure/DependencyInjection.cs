using eBiletServer.Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;

namespace eBiletServer.Infrastructure;
public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddHostedService<SendFailedEmailBackgroundService>();

        return services;
    }
}
