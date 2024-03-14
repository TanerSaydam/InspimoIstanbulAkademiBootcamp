using AutoMapper;
using eBiletServer.Domain.Entities;
using eBiletServer.Domain.Events;
using eBiletServer.Domain.Repositories;
using eBiletServer.Domain.Utilities;
using FluentEmail.Core;
using FluentEmail.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace eBiletServer.Application.Features.Auth.Register;

internal sealed class RegisterCommandHandler(
    UserManager<AppUser> userManager,
    IMediator mediator,
    IMapper mapper) : IRequestHandler<RegisterCommand, Result<string>>
{
    public async Task<Result<string>> Handle(RegisterCommand request, CancellationToken cancellationToken)
    {
        AppUser appUser = mapper.Map<AppUser>(request);
        
        while (true)
        {
            var emailConfirmCode = new Random().Next(111111, 999999);
            if(!userManager.Users.Any(p=> p.EmailConfirmCode == emailConfirmCode))
            {
                appUser.EmailConfirmCode = emailConfirmCode;
                break;
            }
        }

        IdentityResult identityResult = await userManager.CreateAsync(appUser, request.Password);
        if (!identityResult.Succeeded)
        {
            return Result<string>.Failure(identityResult.Errors.Select(s => s.Description).ToHashSet());
        }

        if(appUser.Email is not null)
            await mediator.Publish(new AuthDomainEvent(appUser.Email, appUser.EmailConfirmCode.ToString()));

        return Result<string>.Succeed("User created successfully");
    }

   
}
