using eBiletServer.Domain.Entities;
using eBiletServer.Domain.Repositories;
using eBiletServer.Persistance.Context;
using GenericRepository;

namespace eBiletServer.Persistance.Repositories;
internal sealed class BusRepository : Repository<Bus, ApplicationDbContext>, IBusRepository
{
    public BusRepository(ApplicationDbContext context) : base(context)
    {
    }
}
