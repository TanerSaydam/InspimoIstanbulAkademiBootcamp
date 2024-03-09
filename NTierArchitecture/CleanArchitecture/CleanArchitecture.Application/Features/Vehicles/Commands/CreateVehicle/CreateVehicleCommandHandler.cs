using AutoMapper;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Repositories;
using CleanArchitecture.Domain.Utilities;
using MediatR;

namespace CleanArchitecture.Application.Features.Vehicles.Commands.CreateVehicle;
public sealed class CreateVehicleCommandHandler(
    IVehicleRepository vehicleRepository,
    IMapper mapper) : IRequestHandler<CreateVehicleCommand, Result<string>>
{
    public async Task<Result<string>> Handle(CreateVehicleCommand request, CancellationToken cancellationToken = default)
    {
        bool isPlateExists = await vehicleRepository.AnyAsync(p => p.Plate == request.Plate, cancellationToken);

        if (isPlateExists)
        {
            return Result<string>.Failure("Plate already exists");
        }

        Vehicle vehicle = mapper.Map<Vehicle>(request);

        await vehicleRepository.AddAsync(vehicle, cancellationToken);

        return "Create is successful";
    }
}
