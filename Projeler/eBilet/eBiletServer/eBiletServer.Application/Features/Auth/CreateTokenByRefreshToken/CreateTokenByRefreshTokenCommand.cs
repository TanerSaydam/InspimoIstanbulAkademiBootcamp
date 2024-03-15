using eBiletServer.Domain.Dtos;
using eBiletServer.Domain.Utilities;
using MediatR;

namespace eBiletServer.Application.Features.Auth.CreateTokenByRefreshToken;
public sealed record CreateTokenByRefreshTokenCommand(
    string RefreshToken) : IRequest<Result<LoginResponseDto>>;
