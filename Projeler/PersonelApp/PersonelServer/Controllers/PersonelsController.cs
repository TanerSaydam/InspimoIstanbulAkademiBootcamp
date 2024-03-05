using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using PersonelServer.DTOs;
using PersonelServer.Services;
using System.Text.Json;

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
    [Authorize(AuthenticationSchemes ="Bearer", Roles = "Personels.GetAll")]   
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken = default)
    {
        var response = await personelService.GetAllAsync(cancellationToken);
        return Ok(response);
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