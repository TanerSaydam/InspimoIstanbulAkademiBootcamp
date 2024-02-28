using GenericFileService.Files;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PersonelServer.Context;
using PersonelServer.DTOs;
using PersonelServer.Models;

namespace PersonelServer.Controllers;
[Route("api/[controller]/[action]")]
[ApiController]
public sealed class PersonelsController(
    ApplicationDbContext context) : ControllerBase
{
    [HttpPost]
    public IActionResult Create([FromForm] CreatePersonelDto request)
    {
        //CreatePersonelDtoValidator validator = new();
        //ValidationResult validationResult = validator.Validate(request);
        //if(!validationResult.IsValid)
        //{
        //    throw new ArgumentException(string.Join("\n- ", validationResult.Errors.Select(s => s.ErrorMessage)));
        //}

        bool isIdentityNumberExists = context.Personels.Any(p => p.IdentityNumber == request.IdentityNumber);

        if (isIdentityNumberExists)
        {            
            //throw new ArgumentException("Identity number is already exists");
            throw new IdentityNumberIsAlreadyExistsException();
        }

        string? avatarFileName = null;
        string? cvFileName = null;
        string? diplomaFileName = null;
        List<string>? certificateFileNames = null;
        string? healthReportFile = null;

        if (request.AvatarFile is not null)
        {
            avatarFileName = FileService.FileSaveToServer(request.AvatarFile, "wwwroot/avatars/");
        }

        if (request.CVFile is not null)
        {
            cvFileName = FileService.FileSaveToServer(request.CVFile, "wwwroot/cvs/");
        }

        if (request.DiplomaFile is not null)
        {
            diplomaFileName = FileService.FileSaveToServer(request.DiplomaFile, "wwwroot/diplomas/");
        }

        if (request.HealthReportFile is not null)
        {
            healthReportFile = FileService.FileSaveToServer(request.HealthReportFile, "wwwroot/health-reports/");
        }


        if (request.CertificateFiles is not null)
        {
            certificateFileNames = new();
            foreach (var item in request.CertificateFiles)
            {
                certificateFileNames.Add(FileService.FileSaveToServer(item, "wwwroot/certificates/"));
            }            
        }

        Personel personel = new()
        {
            FirstName = request.FirstName.Trim(),
            LastName = request.LastName.Trim(),
            IdentityNumber = request.IdentityNumber,
            Email = request.Email.ToLower().Trim(),
            PhoneNumber = request.PhoneNumber,
            FullAddress = request.FullAddress.Trim(),
            City = request.City,
            District = request.District,
            Salary = request.Salary,
            StartDate = request.StartDate,
            AvatarUrl = avatarFileName,
            CVUrl = cvFileName,
            DiplomaUrl = diplomaFileName,
            HealthReportUrl = healthReportFile,
            CertificateUrls = 
                    certificateFileNames is not null 
                    ? string.Join(",",certificateFileNames!.AsEnumerable()) 
                    : null,
        };


        context.Add(personel);
        context.SaveChanges();

        return Ok(new {Message = "Personel create is successful"});
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        List<Personel> personels = context.Personels.AsNoTracking().OrderBy(p=> p.FirstName).ToList();

        List<GetAllPersonelDto> response = new();

        foreach (var personel in personels)
        {
            var dtoPersonel = new GetAllPersonelDto()
            {
                FirstName = personel.FirstName,
                LastName = personel.LastName,
                FullName = personel.FullName,
                IdentityNumber = personel.IdentityNumber,
                Email = personel.Email,
                PhoneNumber = personel.PhoneNumber,
                FullAddress = personel.FullAddress,
                City = personel.City,
                District = personel.District,
                Salary = personel.Salary,
                StartDate = personel.StartDate,
                AvatarUrl = personel.AvatarUrl,
                CertificateUrls = 
                            personel.CertificateUrls is not null
                            ? personel.CertificateUrls!.Split(",").ToList()
                            : new List<string>(),
                CVUrl = personel.CVUrl,
                DiplomaUrl = personel.DiplomaUrl,
                HealthReportUrl = personel.HealthReportUrl,
                Id = personel.Id
            };

            response.Add(dtoPersonel);
        }

        return Ok(response);
    }
}


public class IdentityNumberIsAlreadyExistsException : Exception
{
    public IdentityNumberIsAlreadyExistsException(): base("Identity number is already exists")
    {
        
    }
}