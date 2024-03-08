using AutoMapper;
using CleanArchitecture.Application.Services;
using CleanArchitecture.Domain.DTOs;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Repositories;
using CleanArchitecture.Domain.Utilities;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Infrastructure.Services;
internal sealed class VehicleService(
    IVehicleRepository vehicleRepository,
    IMapper mapper) : IVehicleService
{    
    public async Task<Result<string>> AddAsync(VehicleDto request, CancellationToken cancellationToken = default)
    {
        //VehicleDtoValidator validator = new();
        //ValidationResult validationResult = validator.Validate(request);

        //if (!validationResult.IsValid)
        //{
        //    List<string> errors = validationResult.Errors.Select(s=> s.ErrorMessage).ToList();
        //    throw new ArgumentException(string.Join("\n", errors));
        //}


        bool isPlateExists = await vehicleRepository.AnyAsync(p => p.Plate == request.Plate, cancellationToken);

        if (isPlateExists)
        {
            return Result<string>.Failure("Plate already exists");
        }

        Vehicle vehicle = mapper.Map<Vehicle>(request);        

        await vehicleRepository.AddAsync(vehicle, cancellationToken);

        return "Create is successful";
    }

    public async Task<Result<string>> DeleteByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        await vehicleRepository.DeleteByIdAsync(id, cancellationToken);

        return "Delete is successful";
    }

    public async Task<Result<List<Vehicle>>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        var vehicles = await vehicleRepository.GetAll().ToListAsync(cancellationToken);

        return vehicles;
    }

    public async Task<Result<string>> UpdateAsync(Guid id,VehicleDto request, CancellationToken cancellationToken = default)
    {
        Vehicle? vehicle = await vehicleRepository.Where(p => p.Id == id).FirstOrDefaultAsync(cancellationToken);
        if(vehicle is null)
        {
            return Result<string>.Failure("Vehicle not found");
        }
        
        if(vehicle.Plate != request.Plate)
        {
            bool isPlateExists = await vehicleRepository.AnyAsync(p => p.Plate == request.Plate, cancellationToken);

            if(isPlateExists)
            {
                return Result<string>.Failure("Plate already exists");
            }
        }

        mapper.Map(request, vehicle);        
       

        await vehicleRepository.UpdateAsync(vehicle, cancellationToken);

        return "Update is successful";
    }
}
