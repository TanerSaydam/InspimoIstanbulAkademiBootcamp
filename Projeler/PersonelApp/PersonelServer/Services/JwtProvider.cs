using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using PersonelServer.Models;
using PersonelServer.Options;
using PersonelServer.Utilities;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Text.Json;

namespace PersonelServer.Services;

public sealed class JwtProvider
{   
    public string CreateToken(User user, List<string> roles)
    {
        var options = ServiceTool.ServiceProvider!.GetRequiredService<IOptions<JwtOptions>>().Value;

        List<Claim> claims = new()
        {
            new Claim(ClaimTypes.NameIdentifier,user.Id),
            new Claim(ClaimTypes.Name,user.FullName),
            new Claim(ClaimTypes.Email,user.Email),            
        };

        //foreach (var role in roles)
        //{
        //    claims.Add(new Claim(ClaimTypes.Role, role));
        //}

        string key = options.SecretKey;

        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));

        var signinCredentails = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha512);

        JwtSecurityToken jwtSecurityToken = new(
            issuer: options.Issuer,
            audience: options.Audience,
            claims: claims,
            notBefore: DateTime.UtcNow,
            expires: DateTime.Now.AddMonths(12),
            signingCredentials: signinCredentails);

        JwtSecurityTokenHandler handler = new();

        string token = handler.WriteToken(jwtSecurityToken);
        return token;
    }
}
