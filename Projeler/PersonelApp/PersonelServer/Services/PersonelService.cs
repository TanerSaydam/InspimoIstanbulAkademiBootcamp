using AutoMapper;
using GenericFileService.Files;
using Microsoft.EntityFrameworkCore;
using PersonelServer.DTOs;
using PersonelServer.Exceptions;
using PersonelServer.Models;
using PersonelServer.Repositories;
using System.Collections.Generic;
namespace PersonelServer.Services;

public sealed class PersonelService(
    PersonelRepository personelRepository,
    IUnitOfWork unitOfWork,
    IMapper mapper)
{
    public async Task CreateAsync(CreatePersonelDto request, CancellationToken cancellationToken = default)
    {
        #region Business Rules // İş Kuralları
        bool isIdentityNumberExists = await personelRepository.AnyAsync(p => p.IdentityNumber == request.IdentityNumber);

        if (isIdentityNumberExists)
        {
            throw new IdentityNumberIsAlreadyExistsException();
        }

        bool isEmailExists = await personelRepository.AnyAsync(p => p.Email == request.Email);
        if (isEmailExists)
        {
            throw new EmailAddressIsAlreadyExistsException();
        }
        #endregion

        #region Dosyaların Kaydedilmesi
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
        #endregion

        #region Objenin Oluşturulması
        Personel personel = mapper.Map<Personel>(request);
        personel.AvatarUrl = avatarFileName;
        personel.CVUrl = cvFileName;
        personel.DiplomaUrl = diplomaFileName;
        personel.HealthReportUrl = healthReportFile;
        personel.CertificateUrls = certificateFileNames is not null
                    ? string.Join(",", certificateFileNames!.AsEnumerable())
                    : null;
        #endregion

        #region Database'e Kayıt işlemi
        await personelRepository.AddAsync(personel, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);
        #endregion
    }

    public async Task<List<GetAllPersonelDto>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        #region Database'den Listeyi Al
        List<Personel> personels =
           await personelRepository
            .GetAll()
            .Include(p => p.Profession)
            .OrderBy(p => p.FirstName)
            .ToListAsync(cancellationToken);
        #endregion

        #region DTO Nesnesine Dönüştür
        List<GetAllPersonelDto> response = mapper.Map<List<GetAllPersonelDto>>(personels);
        foreach (var personel in personels.Where(p=> p.CertificateUrls is not null))
        {
            GetAllPersonelDto? res = response.FirstOrDefault(p => p.Id == personel.Id);
            if(res is not null)
            {
                res.CertificateFileUrls = personel.CertificateUrls is not null
                        ? personel.CertificateUrls!.Split(",").ToList()
                        : new List<string>();
            }            
        }        
        #endregion

        return response;
    }
}
