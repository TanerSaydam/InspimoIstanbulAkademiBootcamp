using Microsoft.EntityFrameworkCore;
using PersonelServer.Context;
using PersonelServer.Models;

namespace PersonelServer.Repositories;

public sealed class ProfessionRepository : Repository<Profession>
{
    public ProfessionRepository(ApplicationDbContext context) : base(context)
    {
    }
}
