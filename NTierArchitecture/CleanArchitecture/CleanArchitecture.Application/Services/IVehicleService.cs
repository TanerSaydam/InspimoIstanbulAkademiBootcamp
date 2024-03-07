using CleanArchitecture.Domain.DTOs;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.Services;
public interface IVehicleService
{
    Task AddAsync(VehicleDto request, CancellationToken cancellationToken = default);
    Task UpdateAsync(Guid id, VehicleDto request, CancellationToken cancellationToken = default);
    Task DeleteByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task<List<Vehicle>> GetAllAsync(CancellationToken cancellationToken = default);
}
