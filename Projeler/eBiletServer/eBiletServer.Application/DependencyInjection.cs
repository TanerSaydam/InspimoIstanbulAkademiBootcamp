using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace eBiletServer.Application;
public static class DependencyInjection //Extensions metot
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(configuration =>
        {
            configuration.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
        });    

        return services;
    }
}
