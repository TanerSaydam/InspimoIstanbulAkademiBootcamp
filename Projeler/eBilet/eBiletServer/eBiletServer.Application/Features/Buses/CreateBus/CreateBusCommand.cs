using eBiletServer.Domain.Utilities;
using MediatR;

namespace eBiletServer.Application.Features.Buses.CreateBus;
public sealed record CreateBusCommand(
    string Brand,
    int Model,
    string Plate) : IRequest<Result<string>>;
