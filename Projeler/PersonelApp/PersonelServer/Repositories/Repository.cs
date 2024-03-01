using Microsoft.EntityFrameworkCore;
using PersonelServer.Context;
using System.Linq.Expressions;

namespace PersonelServer.Repositories;

public class Repository<T>(
    ApplicationDbContext context)
    where T : class
{
    public async Task<bool> AnyAsync(Expression<Func<T, bool>> predicate)
    {
        return await context.Set<T>().AnyAsync(predicate);
    }

    public async Task AddAsync(T personel, CancellationToken cancellationToken = default)
    {
        await context.AddAsync(personel, cancellationToken);
    }    

    public IQueryable<T> GetAll()
    {
        return context.Set<T>().AsNoTracking().AsQueryable();
    }
}
