using CleanArchitecture.Domain.Enums;
using CleanArchitecture.Domain.Utilities;
using MediatR;

namespace CleanArchitecture.Application.Features.Vehicles.Commands.CreateVehicle;
public sealed record CreateVehicleCommand(
    string Brand,
    string Model,
    string Plate,
    int Year,
    int KM,
    ColorEnum Color) : IRequest<Result<string>>;
