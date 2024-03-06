using CleanArchitecture.Domain.DTOs;

namespace CleanArchitecture.Application.Services;
public interface IVehicleService
{
    Task AddAsync(CreateVehicleDto request, CancellationToken cancellationToken = default);
}
