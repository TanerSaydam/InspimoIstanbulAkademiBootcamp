using eBiletServer.Domain.Entities;
using eBiletServer.Domain.Utilities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace eBiletServer.Application.Features.Auth.Login;
public sealed record LoginCommand(
    string EmailOrUserName,
    string Password) : IRequest<Result<string>>;

internal sealed class LoginCommandHandler(
    SignInManager<AppUser> signInManager,
    UserManager<AppUser> userManager
    ) : IRequestHandler<LoginCommand, Result<string>>
{
    public async Task<Result<string>> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        AppUser? appUser = await userManager.Users.FirstOrDefaultAsync(p =>
                                                                        p.Email == request.EmailOrUserName ||
                                                                        p.UserName == request.EmailOrUserName, cancellationToken);

        if(appUser is null)
        {
            return Result<string>.Failure("User not found");
        }

        SignInResult signInResult = await signInManager.CheckPasswordSignInAsync(appUser, request.Password, false);
        if(!signInResult.Succeeded)
        {
            return Result<string>.Failure("Password is wrong");
        }

        if (signInResult.IsNotAllowed)
        {
            return Result<string>.Failure("Your email is not confirmed");
        }

        if (signInResult.IsLockedOut)
        {
            TimeSpan? timeSpan = appUser.LockoutEnd - DateTime.UtcNow;
            if(timeSpan is not null)
            {
                return Result<string>.Failure($"Your account has been locked for {Math.Ceiling(timeSpan.Value.TotalMinutes)} minutes due to entering the wrong password 3 times");
            }
            else
            {
                return Result<string>.Failure("Your account has been locked out for 5 minutes due to entering the wrong password 3 times");
            }
        }

        string token = Guid.NewGuid().ToString();

        return Result<string>.Succeed(token);
    }
}
