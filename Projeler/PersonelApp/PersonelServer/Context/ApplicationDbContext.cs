using Microsoft.EntityFrameworkCore;
using PersonelServer.Models;

namespace PersonelServer.Context;

public sealed class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Personel> Personels { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Personel>().Property(p => p.FirstName).HasColumnType("varchar(100)");
        modelBuilder.Entity<Personel>().Property(p => p.LastName).HasColumnType("varchar(100)");
        modelBuilder.Entity<Personel>().Property(p => p.IdentityNumber).HasColumnType("varchar(11)");
        modelBuilder.Entity<Personel>().Property(p => p.PhoneNumber).HasColumnType("varchar(10)");
        modelBuilder.Entity<Personel>().Property(p => p.Email).HasColumnType("varchar(300)");
        modelBuilder.Entity<Personel>().Property(p => p.Salary).HasColumnType("money");
        modelBuilder.Entity<Personel>().Property(p => p.StartDate).HasColumnType("date");
        modelBuilder.Entity<Personel>().Property(p => p.City).HasColumnType("varchar(50)");
        modelBuilder.Entity<Personel>().Property(p => p.District).HasColumnType("varchar(50)");
        modelBuilder.Entity<Personel>().Property(p => p.FullAddress).HasColumnType("varchar(300)");

        modelBuilder.Entity<Personel>().HasIndex(i => i.IdentityNumber).IsUnique();
        
    }
}