using eBiletServer.Domain.Entities;
using eBiletServer.Domain.Repositories;
using eBiletServer.Domain.Utilities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace eBiletServer.Application.Features.Buses.GetAllBus;

internal sealed class GetAllBusQueryHandler(
    IBusRepository busRepository) : IRequestHandler<GetAllBusQuery, Result<List<Bus>>>
{
    public async Task<Result<List<Bus>>> Handle(GetAllBusQuery request, CancellationToken cancellationToken)
    {
        List<Bus> buses = await busRepository.GetAll().OrderBy(p => p.Plate).ToListAsync(cancellationToken);

        return buses;
    }
}
