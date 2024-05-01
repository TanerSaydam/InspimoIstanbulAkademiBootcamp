namespace ChatAppServer.WebAPI.Dtos;

public sealed record RegisterDto(
    string FullName,
    string UserName,
    string Password,
    IFormFile File);
