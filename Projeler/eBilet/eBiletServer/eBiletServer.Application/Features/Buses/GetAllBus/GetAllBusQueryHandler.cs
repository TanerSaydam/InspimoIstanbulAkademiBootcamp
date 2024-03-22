using eBiletServer.Domain.Entities;
using eBiletServer.Domain.Repositories;
using eBiletServer.Domain.Utilities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;

namespace eBiletServer.Application.Features.Buses.GetAllBus;

internal sealed class GetAllBusQueryHandler(
    IBusRepository busRepository,
    IMemoryCache memoryCache
    ) : IRequestHandler<GetAllBusQuery, Result<List<Bus>>>
{
    public async Task<Result<List<Bus>>> Handle(GetAllBusQuery request, CancellationToken cancellationToken)
    {
        List<Bus>? buses;
        memoryCache.TryGetValue("buses", out buses);

        if (buses is null)
        {
            buses = await busRepository.GetAll().OrderBy(p => p.Plate).ToListAsync(cancellationToken);
            memoryCache.Set<List<Bus>>("buses", buses,TimeSpan.FromMinutes(60));
        }        

        return buses;
    }
}
