using CleanArchitecture.Domain.Abstractions;
using CleanArchitecture.Domain.Repositories;
using CleanArchitecture.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CleanArchitecture.Infrastructure.Repositories;
internal class Repository<T> : IRepository<T>
    where T : Entity
{
    private readonly ApplicationDbContext _context;
    private readonly DbSet<T> Entity;
    public Repository(ApplicationDbContext context)
    {
        _context = context;
        Entity = context.Set<T>();
    }

    public async Task AddAsync(T entity, CancellationToken cancellationToken = default)
    {
        await Entity.AddAsync(entity, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task<bool> AnyAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default)
    {
        return await Entity.AnyAsync(predicate, cancellationToken);
    }

    public async Task DeleteAsync(T entity, CancellationToken cancellationToken = default)
    {
        Entity.Remove(entity);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        T? entity = await Entity.FindAsync(id, cancellationToken);

        if(entity is not null)
        {
            await DeleteAsync(entity, cancellationToken);
        }
    }

    public IQueryable<T> GetAll()
    {
        return Entity.AsQueryable();
    }

    public async Task UpdateAsync(T entity, CancellationToken cancellationToken = default)
    {
        Entity.Update(entity);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public IQueryable<T> Where(Expression<Func<T, bool>> predicate)
    {
        return Entity.Where(predicate).AsQueryable();
    }
}
