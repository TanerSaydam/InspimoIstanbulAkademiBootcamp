using eBiletServer.Domain.Utilities;
using FluentValidation;
using MediatR;

namespace eBiletServer.Application.Features.Routes.CreateRoute;
public sealed record CreateRouteCommand(
    Guid BusId,
    string From,
    string To,
    string Date) : IRequest<Result<string>>;
