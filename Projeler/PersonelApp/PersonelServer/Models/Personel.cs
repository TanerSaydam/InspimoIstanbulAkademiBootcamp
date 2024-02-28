namespace PersonelServer.Models;

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
}