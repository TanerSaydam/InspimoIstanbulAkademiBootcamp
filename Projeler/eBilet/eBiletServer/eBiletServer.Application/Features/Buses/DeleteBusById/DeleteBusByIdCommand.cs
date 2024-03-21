using eBiletServer.Domain.Utilities;
using MediatR;

namespace eBiletServer.Application.Features.Buses.DeleteBusById;
public sealed record DeleteBusByIdCommand(
    Guid Id): IRequest<Result<string>>;
