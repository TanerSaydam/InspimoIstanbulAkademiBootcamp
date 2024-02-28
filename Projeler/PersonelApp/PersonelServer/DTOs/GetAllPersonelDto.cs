namespace PersonelServer.DTOs;

public sealed record GetAllPersonelDto
{
    public Guid Id { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string FullName { get; set; } = string.Empty;
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
    public List<string>? CertificateUrls { get; set; }
    public string? DiplomaUrl { get; set; }
    public string? HealthReportUrl { get; set; }
};
