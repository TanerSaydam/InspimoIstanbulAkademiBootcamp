using AutoMapper;
using eBiletServer.Application.Extensions;
using eBiletServer.Domain.Entities;
using eBiletServer.Domain.Utilities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace eBiletServer.Application.Features.Auth.Register;

internal sealed class RegisterCommandHandler(
    UserManager<AppUser> userManager,
    IMapper mapper) : IRequestHandler<RegisterCommand, Result<string>>
{
    public async Task<Result<string>> Handle(RegisterCommand request, CancellationToken cancellationToken)
    {
        AppUser appUser = mapper.Map<AppUser>(request);

        IdentityResult identityResult = await userManager.CreateAsync(appUser, request.Password);
        if(!identityResult.Succeeded)
        {
            return Result<string>.Failure(identityResult.Errors.Select(s=> s.Description).ToHashSet());
        }

        return Result<string>.Succeed("User created successfully");
    }
}
