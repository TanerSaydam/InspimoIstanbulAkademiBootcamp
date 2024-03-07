using AutoMapper;
using CleanArchitecture.Application.Services;
using CleanArchitecture.Domain.DTOs;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Infrastructure.Services;
internal sealed class VehicleService(
    IVehicleRepository vehicleRepository,
    IMapper mapper) : IVehicleService
{
    public async Task AddAsync(VehicleDto request, CancellationToken cancellationToken = default)
    {
        bool isPlateExists = await vehicleRepository.AnyAsync(p => p.Plate == request.Plate, cancellationToken);

        if (isPlateExists)
        {
            throw new ArgumentException("Plate already exists");
        }

        Vehicle vehicle = mapper.Map<Vehicle>(request);        

        await vehicleRepository.AddAsync(vehicle, cancellationToken);
        

        //context.Add(vehicle);
        //context.Set<Vehicle>().Add(vehicle);
        // context.Vehicles.Add(vehicle);

        //await context.Vehicles.AddAsync(vehicle, cancellationToken);
       // await context.Set<Vehicle>().AddAsync(vehicle, cancellationToken);
        //await context.AddAsync(vehicle, cancellationToken);

        //await context.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        await vehicleRepository.DeleteByIdAsync(id, cancellationToken);
    }

    public async Task<List<Vehicle>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        var vehicles = await vehicleRepository.GetAll().ToListAsync(cancellationToken);

        return vehicles;
    }

    public async Task UpdateAsync(Guid id,VehicleDto request, CancellationToken cancellationToken = default)
    {
        Vehicle? vehicle = await vehicleRepository.Where(p => p.Id == id).FirstOrDefaultAsync(cancellationToken);
        if(vehicle is null)
        {
            throw new ArgumentException("Vehicle not found");
        }
        
        if(vehicle.Plate != request.Plate)
        {
            bool isPlateExists = await vehicleRepository.AnyAsync(p => p.Plate == request.Plate, cancellationToken);

            if(isPlateExists)
            {
                throw new ArgumentException("Plate already exists");
            }
        }

        mapper.Map(request, vehicle);        
       

        await vehicleRepository.UpdateAsync(vehicle, cancellationToken);
    }
}
