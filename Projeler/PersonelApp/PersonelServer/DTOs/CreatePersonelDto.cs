namespace PersonelServer.DTOs;

public sealed record CreatePersonelDto(
    string FirstName,
    string LastName,
    string StartDate,
    decimal Salary,
    string PhoneNumber,
    string Email,
    string City,
    string District,
    string FullAddress,
    IFormFile? AvatarFile,
    IFormFile? CVFile,
    List<IFormFile>? CertificateFiles,
    IFormFile? DiplomaFile,
    IFormFile? HealthReportFile);