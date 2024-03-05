using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PersonelServer.Context;
using PersonelServer.DTOs;
using PersonelServer.Models;

namespace PersonelServer.Controllers;
[Route("api/[controller]/[action]")]
[ApiController]
[AllowAnonymous]
public sealed class UserRolesController(
    ApplicationDbContext context) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Create(CreateUserRoleDto request, CancellationToken cancellationToken)
    {
        bool isUserHaveThisRole = 
            await context.UserRoles
            .AnyAsync(p=> p.UserId == request.UserId && p.RoleId == request.RoleId, cancellationToken);

        if(isUserHaveThisRole)
        {
            throw new ArgumentException("User have this role already");
        }

        UserRole userRole = new()
        {
            RoleId = request.RoleId,
            UserId = request.UserId,
        };

        context.Add(userRole);

        await context.SaveChangesAsync(cancellationToken);

        return Ok(new { Message = "Create user role is successful" });
    }

    [HttpGet]
    public async Task<IActionResult> GetAllByUserId(string userId, CancellationToken cancellationToken)
    {
        List<Role?> userRoles = 
            await context.UserRoles
            .Where(p => p.UserId == userId)
            .Include(p=> p.Role)
            .Select(s=> s.Role)
            .ToListAsync(cancellationToken);


        return Ok(userRoles);
    }
}
