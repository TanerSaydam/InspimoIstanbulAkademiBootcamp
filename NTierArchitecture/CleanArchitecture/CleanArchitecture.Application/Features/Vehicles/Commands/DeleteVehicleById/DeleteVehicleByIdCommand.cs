using CleanArchitecture.Domain.Utilities;
using MediatR;

namespace CleanArchitecture.Application.Features.Vehicles.Commands.DeleteVehicleById;
public sealed record DeleteVehicleByIdCommand(
    Guid Id) : IRequest<Result<string>>;
