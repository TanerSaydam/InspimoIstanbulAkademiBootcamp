using ChatAppServer.WebAPI.Enums;
using ChatAppServer.WebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ChatAppServer.WebAPI.Context;

public sealed class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>()
            .Property(p=> p.Status)
            .HasConversion(type => type.Value, value => UserStatusEnum.FromValue(value));
    }
}
