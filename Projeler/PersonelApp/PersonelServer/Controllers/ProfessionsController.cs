using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PersonelServer.Repositories;

namespace PersonelServer.Controllers;
[Route("api/[controller]/[action]")]
[ApiController]
public sealed class ProfessionsController(
    ProfessionRepository professionRepository) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
    {
        var professions = 
            await professionRepository
            .GetAll()
            .OrderBy(p=> p.Name)
            .ToListAsync(cancellationToken);

        return Ok(professions);
    }
}
