using TaskManagerServer.Application.Features.Auth.Login;
using TaskManagerServer.Domain.Entities;

namespace TaskManagerServer.Application.Services;
public interface IJwtProvider
{
    Task<LoginCommandResponse> CreateToken(AppUser user);
}
