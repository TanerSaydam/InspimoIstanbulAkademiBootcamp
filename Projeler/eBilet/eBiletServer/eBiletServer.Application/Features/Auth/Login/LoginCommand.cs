using eBiletServer.Application.Services;
using eBiletServer.Domain.Dtos;
using eBiletServer.Domain.Entities;
using eBiletServer.Domain.Utilities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace eBiletServer.Application.Features.Auth.Login;
public sealed record LoginCommand(
    string EmailOrUserName,
    string Password) : IRequest<Result<LoginResponseDto>>;

internal sealed class LoginCommandHandler(
    SignInManager<AppUser> signInManager,
    UserManager<AppUser> userManager,
    IJwtProvider jwtProvider
    ) : IRequestHandler<LoginCommand, Result<LoginResponseDto>>
{
    public async Task<Result<LoginResponseDto>> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        AppUser? appUser = await userManager.Users.FirstOrDefaultAsync(p =>
                                                                        p.Email == request.EmailOrUserName ||
                                                                        p.UserName == request.EmailOrUserName, cancellationToken);

        if(appUser is null)
        {
            return Result<LoginResponseDto>.Failure("User not found");
        }        

        SignInResult signInResult = await signInManager.CheckPasswordSignInAsync(appUser, request.Password, true);

        if (signInResult.IsNotAllowed)
        {
            return Result<LoginResponseDto>.Failure("Your email is not confirmed");
        }

        if (signInResult.IsLockedOut)
        {
            TimeSpan? timeSpan = appUser.LockoutEnd - DateTime.UtcNow;
            if (timeSpan is not null)
            {
                return Result<LoginResponseDto>.Failure($"Your account has been locked for {Math.Ceiling(timeSpan.Value.TotalMinutes)} minutes due to entering the wrong password 3 times");
            }
            else
            {
                return Result<LoginResponseDto>.Failure("Your account has been locked out for 5 minutes due to entering the wrong password 3 times");
            }
        }

        if (!signInResult.Succeeded)
        {
            return Result<LoginResponseDto>.Failure("Password is wrong");
        }

        var response = await jwtProvider.CreateTokenAsync(appUser, cancellationToken);

        return response;
    }
}
