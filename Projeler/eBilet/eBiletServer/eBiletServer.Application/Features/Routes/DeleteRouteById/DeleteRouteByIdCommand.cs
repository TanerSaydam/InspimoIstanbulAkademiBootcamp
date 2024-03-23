using eBiletServer.Domain.Utilities;
using MediatR;

namespace eBiletServer.Application.Features.Routes.DeleteRouteById;
public sealed record DeleteRouteByIdCommand(
    Guid Id) : IRequest<Result<string>>;
