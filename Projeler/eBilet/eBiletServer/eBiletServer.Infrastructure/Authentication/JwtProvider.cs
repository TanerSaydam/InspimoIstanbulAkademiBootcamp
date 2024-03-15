using eBiletServer.Application.Services;
using eBiletServer.Domain.Dtos;
using eBiletServer.Domain.Entities;
using eBiletServer.Domain.Utilities;
using eBiletServer.Infrastructure.Options;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace eBiletServer.Infrastructure.Authentication;
internal sealed class JwtProvider(
    UserManager<AppUser> userManager,
    IOptions<JwtOptions> options) : IJwtProvider
{
    public async Task<Result<LoginResponseDto>> CreateTokenAsync(AppUser appUser, CancellationToken cancellationToken = default)
    {
        List<Claim> claims = new()
        {
            new Claim("UserId", appUser.Id.ToString()),
            new Claim("UserName", appUser.UserName ?? ""),
            new Claim("Email", appUser.Email ?? ""),
            new Claim("FullName", appUser.FullName)
        };

        SymmetricSecurityKey securityKey = new(Encoding.UTF8.GetBytes(options.Value.SecretKey));
        SigningCredentials signingCredentials = new(securityKey, SecurityAlgorithms.HmacSha512);

        DateTime expires = DateTime.UtcNow.AddDays(1);

        JwtSecurityToken jwtSecurityToken = new(
            issuer: options.Value.Issuer,
            audience: options.Value.Audience,
            claims: claims,
            notBefore: DateTime.UtcNow,
            expires: expires,
            signingCredentials: signingCredentials);

        JwtSecurityTokenHandler handler = new();

        string token = handler.WriteToken(jwtSecurityToken);
        string refreshToken = string.Join(".", Guid.NewGuid().ToString(), Guid.NewGuid().ToString());

        while (await userManager.Users.AnyAsync(p => p.RefreshToken == refreshToken, cancellationToken))
        {
            refreshToken = string.Join(".", Guid.NewGuid().ToString(), Guid.NewGuid().ToString());
        }

        DateTime refreshTokenExpires = expires.AddDays(1);

        appUser.RefreshToken = refreshToken;
        appUser.RefreshTokenExpires = refreshTokenExpires;

        IdentityResult identityResult = await userManager.UpdateAsync(appUser);
        if (!identityResult.Succeeded)
        {
            return Result<LoginResponseDto>.Failure(identityResult.Errors.Select(s => s.Description).ToHashSet());
        }

        LoginResponseDto response = new(token, refreshToken, refreshTokenExpires);

        return response;
    }
}
