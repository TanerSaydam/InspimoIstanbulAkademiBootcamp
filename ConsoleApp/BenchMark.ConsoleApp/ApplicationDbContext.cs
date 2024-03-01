using Microsoft.EntityFrameworkCore;

namespace BenchMark.ConsoleApp;
public sealed class ApplicationDbContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Data Source=TANER\\SQLEXPRESS;Initial Catalog=PersonelDb;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False");
    }

    public DbSet<Personel> Personels { get; set; }
    public DbSet<Profession> Professions { get; set; }
}

public sealed class Personel
{
    public Personel()
    {
        Id = Guid.NewGuid();
    }
    public Guid Id { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string FullName => string.Join(" ", FirstName, LastName);
    public string IdentityNumber { get; set; } = string.Empty;
    public DateOnly StartDate { get; set; }
    public decimal Salary { get; set; }
    public string PhoneNumber { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;
    public string District { get; set; } = string.Empty;
    public string FullAddress { get; set; } = string.Empty;
    public string? AvatarUrl { get; set; }
    public string? CVUrl { get; set; }
    public string? CertificateUrls { get; set; }
    public string? DiplomaUrl { get; set; }
    public string? HealthReportUrl { get; set; }

    public Guid ProfessionId { get; set; }
    public Profession? Profession { get; set; }
}

public sealed class Profession
{
    public Profession()
    {
        Id = Guid.NewGuid();
    }
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
}