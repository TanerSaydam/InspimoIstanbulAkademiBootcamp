using eBiletServer.Domain.Entities;
using eBiletServer.Domain.Repositories;
using eBiletServer.Domain.Utilities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace eBiletServer.Application.Features.Routes.GetAllRoute;

internal sealed class GetAllRouteQueryHandler(
    IRouteRepository routeRepository
    ) : IRequestHandler<GetAllRouteQuery, Result<List<Route>>>
{
    public async Task<Result<List<Route>>> Handle(GetAllRouteQuery request, CancellationToken cancellationToken)
    {
        List<Route> routes;

        if(request.From is not null && request.To is not null && request.Date is not null)
        {
            routes = await routeRepository
                .GetWhere(p => 
                    p.From == request.From && 
                    p.To == request.To && DateOnly.FromDateTime(p.Date) == request.Date)
                .Include(p=> p.Bus)
                .OrderBy(p=> p.Date.Hour)
                .ToListAsync(cancellationToken);
        }
        else
        {
            routes = await routeRepository
            .GetAll()
            .Include(p => p.Bus)
            .OrderByDescending(p => p.Date)
            .ToListAsync(cancellationToken);
        }

        return routes;        
    }
}
