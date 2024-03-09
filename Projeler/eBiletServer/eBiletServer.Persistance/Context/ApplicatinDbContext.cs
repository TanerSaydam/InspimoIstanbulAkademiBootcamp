using eBiletServer.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace eBiletServer.Persistance.Context;
internal sealed class ApplicatinDbContext : IdentityDbContext<AppUser, IdentityRole<Guid>, Guid>
{
    public ApplicatinDbContext(DbContextOptions options) : base(options)
    {
    }
}
