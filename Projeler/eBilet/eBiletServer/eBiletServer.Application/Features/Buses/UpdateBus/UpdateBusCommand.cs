using eBiletServer.Domain.Utilities;
using MediatR;

namespace eBiletServer.Application.Features.Buses.UpdateBus;
public sealed record UpdateBusCommand(
    Guid Id,
    string Brand,
    int Model,
    string Plate) : IRequest<Result<string>>;
