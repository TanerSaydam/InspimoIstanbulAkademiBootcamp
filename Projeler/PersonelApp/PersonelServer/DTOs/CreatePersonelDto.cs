namespace PersonelServer.DTOs;

public class CreatePersonelDto
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string StartDate { get; set; } = string.Empty;
    public decimal Salary { get; set; } = 0;
    public string PhoneNumber { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;
    public string District { get; set; } = string.Empty;
    public string FullAddress { get; set; } = string.Empty;
    public IFormFile? AvatarFile { get; set; }
    public IFormFile? CVFile { get; set; }
    public List<IFormFile>? CertificateFiles { get; set; }
    public IFormFile? DiplomaFile { get; set; }
    public IFormFile? HealthReportFile { get; set; }
}