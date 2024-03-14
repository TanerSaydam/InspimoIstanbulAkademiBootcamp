using eBiletServer.Domain.Entities;
using eBiletServer.Domain.Repositories;
using eBiletServer.Persistance.Context;
using eBiletServer.Persistance.Repositories;
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

        services.AddIdentity<AppUser, IdentityRole<Guid>>(
            options =>
            {
                options.SignIn.RequireConfirmedEmail = true;
                options.Password.RequiredLength = 1;
                options.Password.RequireDigit = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Lockout.AllowedForNewUsers = true;
                options.Lockout.MaxFailedAccessAttempts = 3;
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);

            }).AddEntityFrameworkStores<ApplicationDbContext>();

        services.AddScoped<IOutboxSendEmailRepository, OutboxSendEmailRepository>();

        return services;
    }
}
