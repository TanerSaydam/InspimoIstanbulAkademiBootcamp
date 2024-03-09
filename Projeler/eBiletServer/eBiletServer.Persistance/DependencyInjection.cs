using eBiletServer.Domain.Entities;
using eBiletServer.Persistance.Context;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace eBiletServer.Persistance;
public static class DependencyInjection
{
    public static IServiceCollection AddPersistance(this IServiceCollection services)
    {
        services.AddDbContext<ApplicatinDbContext>(options =>
        {
            options.UseInMemoryDatabase("MemoryDb");
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

            }).AddEntityFrameworkStores<ApplicatinDbContext>();

        return services;
    }
}
