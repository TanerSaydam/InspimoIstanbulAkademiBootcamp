using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PersonelServer.Context;
using PersonelServer.Models;

namespace PersonelServer.Controllers;
[Route("api/[controller]/[action]")]
[ApiController]
[AllowAnonymous]
public sealed class RolesController(
    ApplicationDbContext context,
    IConfiguration configuration) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> SyncRoles(CancellationToken cancellationToken)
    {
        var roles = await context.Roles.ToListAsync(cancellationToken);
        List<string> configurationRoles = new();
        configuration.GetSection("Roles").Bind(configurationRoles);

        foreach (var role in roles)
        {
            if(!configurationRoles.Any(p=> p == role.Name))
            {
                context.Remove(role);
            }
        }

        foreach (var role in configurationRoles)
        {
            if(!roles.Any(p=> p.Name == role))
            {
                Role newRole = new()
                {
                    Name = role
                };

                context.Add(newRole);
            }
        }

        await context.SaveChangesAsync(cancellationToken);


        return Ok(new { Message = "Roles sync is successfully" });
    }
}
