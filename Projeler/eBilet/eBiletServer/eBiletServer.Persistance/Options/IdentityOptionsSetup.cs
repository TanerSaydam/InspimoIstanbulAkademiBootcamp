using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;

namespace eBiletServer.Persistance.Options;
public sealed class IdentityOptionsSetup : IPostConfigureOptions<IdentityOptions>
{
    public void PostConfigure(string? name, IdentityOptions options)
    {
        options.SignIn.RequireConfirmedEmail = true;
        options.Password.RequiredLength = 1;
        options.Password.RequireDigit = false;
        options.Password.RequireNonAlphanumeric = false;
        options.Password.RequireUppercase = false;
        options.Password.RequireLowercase = false;
        options.Lockout.AllowedForNewUsers = true;
        options.Lockout.MaxFailedAccessAttempts = 3;
        options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
    }
}
