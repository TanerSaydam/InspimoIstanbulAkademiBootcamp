using Microsoft.EntityFrameworkCore;
using PersonelServer.Models;
using PersonelServer.Repositories;

namespace PersonelServer.Context;

public sealed class ApplicationDbContext : DbContext, IUnitOfWork
{
    public ApplicationDbContext(DbContextOptions options) : base(options)
    {
    }
    public DbSet<Personel> Personels { get; set; }
    public DbSet<Profession> Professions { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        #region Personel
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
        #endregion

        #region Profession
        modelBuilder.Entity<Profession>().Property(p => p.Name).HasColumnType("varchar(100)");
        modelBuilder.Entity<Profession>().HasIndex(i => i.Name).IsUnique();
        #endregion

        #region SeedData
        List<Profession> professions = new()
        {
            new Profession()
            {
                Id = Guid.Parse("36745468-c99a-483c-b57e-08bfe168fd64"),
                Name = "Software Developer"
            },
            new Profession()
            {
                Id = Guid.Parse("50edf3c8-089f-481e-a389-0450c18834d3"),
                Name = "Teacher"
            },
            new Profession()
            {
                Id = Guid.Parse("0d4a950d-269b-4aaa-bbd1-32b6832d3cf8"),
                Name = "Frontend Developer"
            },
            new Profession()
            {
                Id = Guid.Parse("18b44f34-a078-4fc0-9ee1-5e5c7b0b1ceb"),
                Name = "Full Stack Developer"
            },
        };


        modelBuilder.Entity<Profession>().HasData(professions);
        #endregion
    }    
}