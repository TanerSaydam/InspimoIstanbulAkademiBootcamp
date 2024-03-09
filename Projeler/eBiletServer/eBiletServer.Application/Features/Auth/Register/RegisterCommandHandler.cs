using eBiletServer.Application.Extensions;
using eBiletServer.Domain.Entities;
using eBiletServer.Domain.Utilities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace eBiletServer.Application.Features.Auth.Register;

internal sealed class RegisterCommandHandler(
    UserManager<AppUser> userManager) : IRequestHandler<RegisterCommand, Result<string>>
{
    public async Task<Result<string>> Handle(RegisterCommand request, CancellationToken cancellationToken)
    {
        string userName = request.UserName.ReplaceAllTurkishLettersAndDeleteEmpty();
        string email = request.Email.ReplaceAllTurkishLettersAndDeleteEmpty();

        bool isEmailExists = await userManager.Users.AnyAsync(p => p.Email == email, cancellationToken);
        if (isEmailExists)
        {
            return Result<string>.Failure("Bu mail adresi daha önce kullanılmış");
        }

        bool isUserNameExists = await userManager.Users.AnyAsync(p => p.UserName == userName, cancellationToken);
        if (isUserNameExists)
        {
            return Result<string>.Failure("Kullanıcı adı daha önce kullanılmış");
        }

        AppUser appUser = new()
        {
            FirstName = request.FirstName,
            LastName = request.LastName,
            Email = email,
            UserName = userName,
        };

        IdentityResult identityResult = await userManager.CreateAsync(appUser, request.Password);
        if(!identityResult.Succeeded)
        {
            return Result<string>.Failure(identityResult.Errors.Select(s=> s.Description).ToHashSet());
        }

        return Result<string>.Succeed("User created successfully");
    }
}
