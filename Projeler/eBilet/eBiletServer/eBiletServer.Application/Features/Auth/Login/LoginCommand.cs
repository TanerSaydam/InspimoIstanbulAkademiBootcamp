using eBiletServer.Domain.Dtos;
using eBiletServer.Domain.Utilities;
using MediatR;

namespace eBiletServer.Application.Features.Auth.Login;
public sealed record LoginCommand(
    string EmailOrUserName,
    string Password) : IRequest<Result<LoginResponseDto>>;
