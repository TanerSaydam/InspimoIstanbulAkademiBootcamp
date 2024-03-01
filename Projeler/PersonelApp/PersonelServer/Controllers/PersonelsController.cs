using Microsoft.AspNetCore.Mvc;
using PersonelServer.DTOs;
using PersonelServer.Services;
using System.Text.Json;

namespace PersonelServer.Controllers;
[Route("api/[controller]/[action]")]
[ApiController]
public sealed class PersonelsController(
    PersonelService personelService) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Create([FromForm] CreatePersonelDto request, CancellationToken cancellationToken = default)
    {   
        await personelService.CreateAsync(request, cancellationToken);
        return Ok(new ResponseDto("Personel create is successful"));
    }

    [HttpGet]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken = default)
    {
        await Task.Delay(15000,cancellationToken);
        var response = await personelService.GetAllAsync(cancellationToken);
        return Ok(response);
    }
}