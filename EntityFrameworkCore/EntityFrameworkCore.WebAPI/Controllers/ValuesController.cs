using AutoMapper;
using EntityFrameworkCore.WebAPI.Context;
using EntityFrameworkCore.WebAPI.DTOs;
using EntityFrameworkCore.WebAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkCore.WebAPI.Controllers;
[Route("api/[controller]/[action]")]
[ApiController]
public class ValuesController(
    ApplicationDbContext context,
    IMapper mapper) : ControllerBase
{
    [HttpGet] //bunu kontrol ettik 
    //ctrl m + o
    public IActionResult GetAll()
    {
        List<Personel> response = 
            context.Personels
            .AsNoTracking()
            .OrderBy(p=> p.FirstName)
            .ToList();  

        return Ok(response);
    }

    [HttpPost]
    public IActionResult Create(CreatePersonelDto request)
    {
        Personel personel = mapper.Map<Personel>(request);

        context.Personels.Add(personel);
        int result = context.SaveChanges();

        return Ok(new { Message = "Kayıt başarıyla tamamlandı" });
    }

    [HttpPost] //Create Read Update Delete => CRUD operations
    public IActionResult Update(UpdatePersonelDto request)
    {
        Personel? personel = context.Personels.FirstOrDefault(p => p.Id == request.Id);
        
        if(personel is null)
        {
            return StatusCode(500, new { Message = "Bu personel kaydı bulunamadı!" });
        }

        mapper.Map(request, personel);

        //context.Personels.Update(personel);
        context.SaveChanges();

        return Ok(new { Message = "Personel kaydı başarıyla güncellendi" });
    }

    [HttpGet]
    public IActionResult DeleteById(Guid id)
    {
        Personel? personel = context.Personels.Find(id);

        if (personel is null)
        {
            return StatusCode(500, new { Message = "Bu personel kaydı bulunamadı!" });
        }

        context.Personels.Remove(personel);
        context.SaveChanges();

        return Ok(new { Message = "Silme işlemi başarıyla tamamlandı" });
    }

    
}
