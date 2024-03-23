using eBiletServer.Application.Services;
using eBiletServer.Domain.Entities;
using eBiletServer.Domain.Repositories;
using eBiletServer.Domain.Utilities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using StackExchange.Redis;
using System.Text.Json;

namespace eBiletServer.Application.Features.Buses.GetAllBus;

internal sealed class GetAllBusQueryHandler(
    IBusRepository busRepository,
    RedisService redisService
    ) : IRequestHandler<GetAllBusQuery, Result<List<Bus>>>
{
    //11:23 görüşelim
    public async Task<Result<List<Bus>>> Handle(GetAllBusQuery request, CancellationToken cancellationToken)
    {
        List<Bus>? buses;
        RedisValue redisValue = redisService.Get("bus");

        if (redisValue.IsNull)
        {
            buses = await busRepository.GetAll().OrderBy(p => p.Plate).ToListAsync(cancellationToken);
            redisService.Set("bus", buses);
        }
        else
        {
            buses = JsonSerializer.Deserialize<List<Bus>>(redisValue);
        }      

        return buses;
    }
}
