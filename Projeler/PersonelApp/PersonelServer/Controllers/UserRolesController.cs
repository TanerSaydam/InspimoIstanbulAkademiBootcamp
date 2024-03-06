using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PersonelServer.Context;
using PersonelServer.DTOs;
using PersonelServer.Models;
using System.Security.Claims;

namespace PersonelServer.Controllers;
[Route("api/[controller]/[action]")]
[ApiController]
public sealed class UserRolesController(
    ApplicationDbContext context) : ControllerBase
{
    [HttpPost]
    [AllowAnonymous]
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
    public async Task<IActionResult> GetAllByUserId(CancellationToken cancellationToken)
    {
        string? userId = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
        if(userId is null)
        {
            throw new ArgumentException("User not found");
        }

        List<Role?> userRoles = 
            await context.UserRoles
            .Where(p => p.UserId == userId)
            .Include(p=> p.Role)
            .Select(s=> s.Role)
            .ToListAsync(cancellationToken);


        return Ok(userRoles.Select(s=> s!.Name));
    }

    [HttpGet]
    public async Task<IActionResult> IsItAuthorized(string role, CancellationToken cancellationToken)
    {
        string? userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)!.Value;
        if(userId == null)
        {
            throw new ArgumentException("User nor found");
        }

       var response = 
            await context.UserRoles
            .Where(p => p.UserId == userId && p.Role!.Name == role)
            .Include(p => p.Role)
            .AnyAsync(cancellationToken);

        return Ok(new { IsItAuthorized = response });
    }
}
