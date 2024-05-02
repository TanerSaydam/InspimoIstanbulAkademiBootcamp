using ChatAppServer.WebAPI.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ChatAppServer.WebAPI.Controllers;
[Route("api/[controller]/[action]")]
[ApiController]
public class UsersController(ApplicationDbContext context) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
    {
        var users = await context.Users.OrderBy(p => p.FullName).ToListAsync(cancellationToken);

        return Ok(users);
    }
}
