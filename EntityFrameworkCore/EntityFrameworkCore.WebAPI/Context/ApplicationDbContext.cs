using EntityFrameworkCore.WebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkCore.WebAPI.Context;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions options) : base(options)
    {
        
    }

    public DbSet<Personel> Personels { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Personel>().Property(p => p.FirstName).HasColumnType("varchar(100)");
        modelBuilder.Entity<Personel>().Property(p => p.LastName).HasColumnType("varchar(100)");
        modelBuilder.Entity<Personel>().Property(p => p.Email).HasColumnType("varchar(500)");
        modelBuilder.Entity<Personel>().HasIndex(i => i.Email).IsUnique(true);
    }
}