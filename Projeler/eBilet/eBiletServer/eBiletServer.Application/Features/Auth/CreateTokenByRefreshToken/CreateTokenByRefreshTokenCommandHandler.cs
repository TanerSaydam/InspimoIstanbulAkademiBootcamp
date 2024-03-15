using eBiletServer.Application.Services;
using eBiletServer.Domain.Dtos;
using eBiletServer.Domain.Entities;
using eBiletServer.Domain.Utilities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace eBiletServer.Application.Features.Auth.CreateTokenByRefreshToken;

internal sealed class CreateTokenByRefreshTokenCommandHandler(
    UserManager<AppUser> userManager,
    IJwtProvider jwtProvider
    ) : IRequestHandler<CreateTokenByRefreshTokenCommand, Result<LoginResponseDto>>
{
    public async Task<Result<LoginResponseDto>> Handle(CreateTokenByRefreshTokenCommand request, CancellationToken cancellationToken)
    {
        AppUser? appUser = await userManager.Users.FirstOrDefaultAsync(p=> p.RefreshToken == request.RefreshToken, cancellationToken);
        if(appUser is null)
        {
            return Result<LoginResponseDto>.Failure("Refresh token is not valid");
        }

        TimeSpan? timeSpan = appUser.RefreshTokenExpires - DateTime.UtcNow;

        if(timeSpan is null)
        {
            
        }

        if(timeSpan!.Value.TotalSeconds <= 0)
        {
            return Result<LoginResponseDto>.Failure("Refresh token is not valid");           
        }

        var response = await jwtProvider.CreateTokenAsync(appUser, cancellationToken);

        return response;
    }
}
