using CleanArchitecture.Domain.DTOs;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Utilities;

namespace CleanArchitecture.Application.Services;
public interface IVehicleService
{
    Task<Result<string>> AddAsync(VehicleDto request, CancellationToken cancellationToken = default);
    Task<Result<string>> UpdateAsync(Guid id, VehicleDto request, CancellationToken cancellationToken = default);
    Task<Result<string>> DeleteByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task<Result<List<Vehicle>>> GetAllAsync(CancellationToken cancellationToken = default);
}
