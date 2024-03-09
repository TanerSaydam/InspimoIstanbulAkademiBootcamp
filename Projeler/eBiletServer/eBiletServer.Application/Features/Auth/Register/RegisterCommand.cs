using eBiletServer.Domain.Utilities;
using MediatR;

namespace eBiletServer.Application.Features.Auth.Register;
public sealed record RegisterCommand(
    string FirstName,
    string LastName,
    string Email,
    string UserName,
    string Password) : IRequest<Result<string>>;
