using Microsoft.AspNetCore.Identity;

namespace eBiletServer.Domain.Entities;
public sealed class AppUser : IdentityUser<Guid>
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string FullName => string.Join(" ", FirstName, LastName);

    public int EmailConfirmCode { get; set; }

    public string? RefreshToken { get; set; }
    public DateTime? RefreshTokenExpires { get; set; }
}
