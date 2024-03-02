using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PersonelServer.DTOs;
using PersonelServer.Services;

namespace PersonelServer.Controllers;
[Route("api/[controller]/[action]")]
[ApiController]
[AllowAnonymous]
public class AuthController(
    UserService userService) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Register(CreateUserDto request, CancellationToken cancellationToken)
    {
        await userService.CreateAsync(request, cancellationToken);
        return Ok(new { Message = "User create is succeed" });
    } 
    
    [HttpPost]
    public async Task<IActionResult> Login(LoginDto request, CancellationToken cancellationToken)
    {
        string token = await userService.LoginAsync(request, cancellationToken);
        return Ok(new { Token = token });
    }
}
