using Microsoft.EntityFrameworkCore;
using PersonelServer.Context;
using System.Linq.Expressions;

namespace PersonelServer.Repositories;

public class Repository<T>(
    ApplicationDbContext context)
    where T : class
{
    public bool Any(Expression<Func<T, bool>> predicate)
    {
        return context.Set<T>().Any(predicate);
    }

    public void Add(T personel)
    {
        context.Add(personel);
    }    

    public IQueryable<T> GetAll()
    {
        return context.Set<T>().AsNoTracking().AsQueryable();
    }
}
