using AutoMapper;
using ChatAppServer.WebAPI.Context;
using ChatAppServer.WebAPI.Dtos;
using ChatAppServer.WebAPI.Models;
using GenericFileService.Files;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ChatAppServer.WebAPI.Controllers;
[Route("api/[controller]/[action]")]
[ApiController]
public sealed class AuthController(
    ApplicationDbContext context,
    IMapper mapper) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Register([FromForm] RegisterDto request, CancellationToken cancellationToken)
    {
        string userName = request.UserName.Replace(" ", "").ToLower();
        bool isUserNameExists = await context.Users.AnyAsync(p => p.UserName == userName, cancellationToken);

        if(isUserNameExists)
        {
            return BadRequest(new { Message = "Bu kullanıcı adı daha önce kaydedilmiş" });
        }

        User user = mapper.Map<User>(request);

        user.AvatarUrl = FileService.FileSaveToServer(request.File, "wwwroot/avatar/");

        await context.AddAsync(user, cancellationToken);

        await context.SaveChangesAsync(cancellationToken);

        return Ok(user);
    }

    [HttpGet]
    public async Task<IActionResult> Login(string userName, string password, CancellationToken cancellationToken)
    {
        userName = userName.ToLower();

        User? user = await context.Users
            .FirstOrDefaultAsync(p=> 
            p.UserName == userName && 
            p.Password == password, cancellationToken);

        if(user is null)
        {
            return BadRequest(new { Message = "Kullanıcı bulunamadı" });
        }

        return Ok(user);
    }
}
