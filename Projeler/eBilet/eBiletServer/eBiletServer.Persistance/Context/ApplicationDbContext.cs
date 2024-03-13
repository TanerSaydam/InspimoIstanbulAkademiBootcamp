using eBiletServer.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace eBiletServer.Persistance.Context;
internal sealed class ApplicationDbContext : IdentityDbContext<AppUser, IdentityRole<Guid>, Guid>
{
    public ApplicationDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<OutboxSendEmail> OutboxSendEmails { get; set; }
}
