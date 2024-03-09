using Microsoft.AspNetCore.Mvc;

namespace eBiletServer.Prestantion.Controllers;
[ApiController]
[Route("api/[controller]/[action]")]
public sealed class AuthController : ControllerBase
{
    [HttpGet]
    public IActionResult Get()
    {
        return Ok();
    }
}
