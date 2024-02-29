using Microsoft.AspNetCore.Mvc;
using PersonelServer.DTOs;
using PersonelServer.Services;

namespace PersonelServer.Controllers;
[Route("api/[controller]/[action]")]
[ApiController]
public sealed class PersonelsController(
    PersonelService personelService) : ControllerBase
{
    [HttpPost]
    public IActionResult Create([FromForm] CreatePersonelDto request)
    {
        personelService.Create(request);
        return Ok(new ResponseDto("Personel create is successful"));
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var response = personelService.GetAll();
        return Ok(response);
    }
}