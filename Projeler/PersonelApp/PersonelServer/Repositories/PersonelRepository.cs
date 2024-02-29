using Microsoft.EntityFrameworkCore;
using PersonelServer.Context;
using PersonelServer.Models;
using System.Linq.Expressions;

namespace PersonelServer.Repositories;

public sealed class PersonelRepository : Repository<Personel>
{
    public PersonelRepository(ApplicationDbContext context) : base(context)
    {
    }
}
