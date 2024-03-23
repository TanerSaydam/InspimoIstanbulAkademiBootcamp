using eBiletServer.Domain.Entities;
using eBiletServer.Domain.Utilities;
using MediatR;

namespace eBiletServer.Application.Features.Routes.GetAllRoute;
public sealed record GetAllRouteQuery(
    string? From,
    string? To,
    DateOnly? Date) : IRequest<Result<List<Route>>>;
