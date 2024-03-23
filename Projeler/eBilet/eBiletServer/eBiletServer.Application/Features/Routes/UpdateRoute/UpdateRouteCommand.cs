using eBiletServer.Domain.Utilities;
using MediatR;

namespace eBiletServer.Application.Features.Routes.UpdateRoute;
public sealed record UpdateRouteCommand(
    Guid Id,
    Guid BusId,
    string From,
    string To,
    string Date) : IRequest<Result<string>>;



