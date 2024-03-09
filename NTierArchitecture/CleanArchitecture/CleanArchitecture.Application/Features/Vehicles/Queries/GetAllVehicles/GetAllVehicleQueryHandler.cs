using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Repositories;
using CleanArchitecture.Domain.Utilities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Application.Features.Vehicles.Queries.GetAllVehicles;
internal sealed class GetAllVehicleQueryHandler(
    IVehicleRepository vehicleRepository) : IRequestHandler<GetAllVehicleQuery, Result<List<GetAllVehicleQueryResponse>>>
{
    public async Task<Result<List<GetAllVehicleQueryResponse>>> Handle(GetAllVehicleQuery request, CancellationToken cancellationToken)
    {
        var vehicles = await vehicleRepository.GetAll().Select(s=> new GetAllVehicleQueryResponse(
            s.Id,
            s.Brand,
            s.Model,
            s.Plate,
            s.Year,
            s.KM,
            s.Color)).ToListAsync(cancellationToken);

        return vehicles;
    }
}
