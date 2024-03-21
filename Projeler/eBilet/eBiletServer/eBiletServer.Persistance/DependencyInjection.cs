using eBiletServer.Domain.Entities;
using eBiletServer.Domain.Repositories;
using eBiletServer.Persistance.Context;
using eBiletServer.Persistance.Options;
using eBiletServer.Persistance.Repositories;
using GenericRepository;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace eBiletServer.Persistance;
public static class DependencyInjection
{
    public static IServiceCollection AddPersistance(this IServiceCollection services)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseNpgsql("Host=localhost;Port=5432;Database=ebiletdb;Username=postgres;Password=1;");
            options.UseSnakeCaseNamingConvention();
        });

        services.AddScoped<IUnitOfWork>(srv => srv.GetRequiredService<ApplicationDbContext>());

        services.ConfigureOptions<IdentityOptionsSetup>();
        services.AddIdentity<AppUser, IdentityRole<Guid>>(options =>
        {
            options.Password.RequiredLength = 1;
            options.Password.RequireUppercase = false;
            options.Password.RequireUppercase = false;
            options.Password.RequireNonAlphanumeric = false;
            options.Password.RequireDigit = false;            
        }).AddEntityFrameworkStores<ApplicationDbContext>();

        services.AddScoped<IOutboxSendEmailRepository, OutboxSendEmailRepository>();
        services.AddScoped<IBusRepository, BusRepository>();
        return services;
    }
}
