using eBiletServer.Application.Extensions;
using eBiletServer.Domain.Entities;
using eBiletServer.Domain.Utilities;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace eBiletServer.Application.Features.Auth.VerifyEmailByEmailConfirmCode;

internal sealed class VerifyEmailByEmailConfirmCodeCommandHandler(
    UserManager<AppUser> userManager) : IRequestHandler<VerifyEmailByEmailConfirmCodeCommand, Result<string>>
{
    public async Task<Result<string>> Handle(VerifyEmailByEmailConfirmCodeCommand request, CancellationToken cancellationToken)
    {
        AppUser? appUser = await userManager.FindByEmailConfirmCode(request.EmailConfirmCode, cancellationToken);

        if(appUser is null)
        {
            return Result<string>.Failure("Email confirm code is not valid");
        }

        if (appUser.EmailConfirmed)
        {
            return Result<string>.Failure("Email already confirmed");
        }

        appUser.EmailConfirmed = true;
        IdentityResult identityResult = await userManager.UpdateAsync(appUser);
        if(!identityResult.Succeeded)
        {
            return Result<string>.Failure(identityResult.Errors.Select(s => s.Description).ToHashSet());
        }

        return Result<string>.Succeed("Email confirm is successful");
    }
}
