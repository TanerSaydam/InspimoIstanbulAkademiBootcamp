using eBiletServer.Domain.Entities;
using eBiletServer.Domain.Repositories;
using eBiletServer.Persistance.Context;
using GenericRepository;

namespace eBiletServer.Persistance.Repositories;
internal sealed class RouteRepository : Repository<Route, ApplicationDbContext>, IRouteRepository
{
    public RouteRepository(ApplicationDbContext context) : base(context)
    {
    }
}
