using PersonelServer.Context;
using PersonelServer.Models;

namespace PersonelServer.Repositories;

public sealed class UserRepository : Repository<User>
{
    public UserRepository(ApplicationDbContext context) : base(context)
    {
    }
}
