using AutoMapper;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Repositories;
using CleanArchitecture.Domain.Utilities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Application.Features.Vehicles.Commands.UpdateVehicle;
internal sealed class UpdateVehicleCommandHandler(
    IVehicleRepository vehicleRepository,
    IMapper mapper) : IRequestHandler<UpdateVehicleCommand, Result<string>>
{
    public async Task<Result<string>> Handle(UpdateVehicleCommand request, CancellationToken cancellationToken)
    {
        Vehicle? vehicle = await vehicleRepository.Where(p => p.Id == request.Id).FirstOrDefaultAsync(cancellationToken);
        if (vehicle is null)
        {
            return Result<string>.Failure("Vehicle not found");
        }

        if (vehicle.Plate != request.Plate)
        {
            bool isPlateExists = await vehicleRepository.AnyAsync(p => p.Plate == request.Plate, cancellationToken);

            if (isPlateExists)
            {
                return Result<string>.Failure("Plate already exists");
            }
        }

        mapper.Map(request, vehicle);


        await vehicleRepository.UpdateAsync(vehicle, cancellationToken);

        return "Update is successful";
    }
}
