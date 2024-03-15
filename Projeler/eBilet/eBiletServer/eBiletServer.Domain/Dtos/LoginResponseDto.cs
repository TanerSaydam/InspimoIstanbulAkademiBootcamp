namespace eBiletServer.Domain.Dtos;
public sealed record LoginResponseDto(
    string Token,
    string RefreshToken,
    DateTime RefreshTokenExpires);
