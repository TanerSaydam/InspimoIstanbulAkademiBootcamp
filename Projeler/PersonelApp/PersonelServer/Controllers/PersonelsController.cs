using GenericFileService.Files;
using Microsoft.AspNetCore.Mvc;
using PersonelServer.DTOs;

namespace PersonelServer.Controllers;
[Route("api/[controller]/[action]")]
[ApiController]
public sealed class PersonelsController : ControllerBase
{
    [HttpPost]
    public IActionResult Create([FromForm] CreatePersonelDto request)
    {
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


        return Ok();
    }    

}
