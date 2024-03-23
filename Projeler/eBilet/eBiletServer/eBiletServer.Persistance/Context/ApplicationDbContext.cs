using eBiletServer.Application.Services;
using eBiletServer.Domain.Entities;
using GenericRepository;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace eBiletServer.Persistance.Context;
internal sealed class ApplicationDbContext : IdentityDbContext<AppUser, IdentityRole<Guid>, Guid>, IUnitOfWork
{
    private readonly RedisService _redisService;
    public ApplicationDbContext(DbContextOptions options, RedisService redisService) : base(options)
    {
        _redisService = redisService;
    }

    public DbSet<OutboxSendEmail> OutboxSendEmails { get; set; }
    public DbSet<Bus> Buses { get; set; }
    public DbSet<Route> Routes { get; set; }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        var modifiedEntityEntries = ChangeTracker.Entries()
            .Where(entry =>
            entry.State == EntityState.Added ||
            entry.State == EntityState.Modified ||
            entry.State == EntityState.Deleted);

        var modifiedEntityNames = modifiedEntityEntries
            .Select(entry => entry.Entity.GetType().Name)
            .Distinct()
            .ToList();

        var result = await base.SaveChangesAsync(cancellationToken);

        if(result > 0)
        {
            foreach (var entityName in modifiedEntityNames)
            {
                if(entityName is not null)
                {
                    _redisService.Delete(entityName.ToLower());
                }
            }
        }

        return result;
    }
}
