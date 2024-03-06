using Humanizer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using PersonelServer.Context;
using PersonelServer.DTOs;
using PersonelServer.Services;
using PersonelServer.Utilities;
using System.Security.Claims;

namespace PersonelServer.Controllers;
[Route("api/[controller]/[action]")]
[ApiController]
//[AllowAnonymous]
//[Authorize(AuthenticationSchemes = "Bearer")]
public sealed class PersonelsController(
    PersonelService personelService) : ControllerBase
{
    [HttpPost]
    //[Authorize(AuthenticationSchemes = "Bearer")]
    public async Task<IActionResult> Create([FromForm] CreatePersonelDto request, CancellationToken cancellationToken = default)
    {   
        await personelService.CreateAsync(request, cancellationToken);
        return Ok(new ResponseDto("Personel create is successful"));
    }

    [HttpGet]
    [Authorize(AuthenticationSchemes ="Bearer")]
    [AuthorizeFilter("Professions.GetAll")]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken = default)
    {
        var response = await personelService.GetAllAsync(cancellationToken);
        return Ok(response);
    }
}

public class AuthorizeFilterAttribute(
    string role
    ) : Attribute, IAuthorizationFilter
{    
    public void OnAuthorization(AuthorizationFilterContext context)
    {
        ApplicationDbContext dbContext = context.HttpContext.RequestServices.GetRequiredService<ApplicationDbContext>();
        //ApplicationDbContext dbContext = ServiceTool.ServiceProvider!.GetRequiredService<ApplicationDbContext>();  

        string? userId = context.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);

        if (userId is null) throw new UnauthorizedAccessException();

        bool isAuthorized = dbContext.UserRoles.Include(p => p.Role).Any(p => p.UserId == userId && p.Role!.Name == role);

        if (!isAuthorized) throw new UnauthorizedAccessException();
    }
}

public class AuthorizeCheck : Attribute, IAuthorizationFilter
{
    public void OnAuthorization(AuthorizationFilterContext context)
    {
        var authorization = context.HttpContext.Request.Headers.Where(p => p.Key == "Authorization").FirstOrDefault();
        string? value = authorization.Value;

        

        if (string.IsNullOrEmpty(value) || value != "Taner Saydam")
        {            
            throw new UnauthorizedAccessException();
        }
            
    }
}