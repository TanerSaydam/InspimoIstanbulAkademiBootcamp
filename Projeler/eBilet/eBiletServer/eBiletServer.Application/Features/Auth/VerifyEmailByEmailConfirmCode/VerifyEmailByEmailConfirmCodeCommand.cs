using eBiletServer.Domain.Utilities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace eBiletServer.Application.Features.Auth.VerifyEmailByEmailConfirmCode;
public sealed record VerifyEmailByEmailConfirmCodeCommand(
    int EmailConfirmCode): IRequest<Result<string>> ;
