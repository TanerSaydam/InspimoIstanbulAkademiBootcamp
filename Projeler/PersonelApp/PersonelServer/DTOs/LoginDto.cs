namespace PersonelServer.DTOs;

public sealed record LoginDto(
    string Email,
    string Password);
