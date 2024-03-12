using eBiletServer.Application.Extensions;
using eBiletServer.Domain.Entities;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace eBiletServer.Application.Features.Auth.Register;
public sealed class RegisterCommandValidator : AbstractValidator<RegisterCommand>
{
    public RegisterCommandValidator(UserManager<AppUser> userManager)
    {
        RuleFor(p => p.UserName)
            .Matches("^[a-z0-9]+$")
            .MustAsync(async (userName, cancellationToken)=>
            {
                bool isUserNameExists = await userManager.Users
                                .AnyAsync(p =>
                                p.UserName == userName.ReplaceAllTurkishLettersAndDeleteEmptySpace(),
                                cancellationToken);

                return !isUserNameExists;
            })
            .WithMessage("Kullanıcı adı daha önce kullanılmış")
            .MustAsync(async (email, cancellationToken)=>
            {
                bool isEmailExists = await userManager.Users
                                .AnyAsync(p =>
                                p.Email == email.ReplaceAllTurkishLettersAndDeleteEmptySpace(),
                                cancellationToken);

                return !isEmailExists;
            })
            .WithMessage("Bu mail adresi daha önce kullanılmış");
    }
}
