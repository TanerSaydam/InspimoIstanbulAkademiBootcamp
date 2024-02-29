using Microsoft.AspNetCore.Mvc;
using PersonelServer.Repositories;

namespace PersonelServer.Controllers;
[Route("api/[controller]/[action]")]
[ApiController]
public sealed class ProfessionsController(
    ProfessionRepository professionRepository) : ControllerBase
{
    [HttpGet]
    public IActionResult GetAll()
    {
        var professions = 
            professionRepository
            .GetAll()
            .OrderBy(p=> p.Name)
            .ToList();

        return Ok(professions);
    }
}
