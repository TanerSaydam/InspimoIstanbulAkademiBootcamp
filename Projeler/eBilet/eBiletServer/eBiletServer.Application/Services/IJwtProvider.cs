using eBiletServer.Domain.Dtos;
using eBiletServer.Domain.Entities;
using eBiletServer.Domain.Utilities;

namespace eBiletServer.Application.Services;
public interface IJwtProvider
{
    Task<Result<LoginResponseDto>> CreateTokenAsync(AppUser appUser, CancellationToken cancellationToken = default);
}
