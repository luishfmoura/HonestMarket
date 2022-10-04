using HonestMarket.Domain.Core.Repositories;
using HonestMarket.Domain.Entities;
using HonestMarket.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace HonestMarket.Infra.Data.Repositories;

public class RepositoryBase<T> : IRepositoryBase<T> where T : BaseEntity
{
    private readonly HonestMarketContext _context;

    public RepositoryBase(HonestMarketContext context)
    {
        _context = context;
    }

    public bool Add(T entity)
    {
        _context.Set<T>().Add(entity);
        return _context.SaveChanges() > 0;
    }

    public ICollection<T>? Get()
    {
        return _context.Set<T>()
               .AsNoTracking()
               .ToList();
    }

    public T? Get(int id)
    {
        var entity = _context.Set<T>()
                             .Find(id);
        if (entity is not null)
        {
            _context.Entry(entity).State = EntityState.Detached;
        }

        return entity;
    }

    public T? Get(string guid)
    {
        var entity = _context.Set<T>()
                             .Where(e => e.Guid.ToString() == guid)
                             .AsNoTracking()
                             .FirstOrDefault();

        return entity;
    }

    public ICollection<T>? Get(Func<T, bool> lambda)
    {
        return _context.Set<T>()
                       .AsNoTracking()
                       .Where(lambda)
                       .ToList();
    }

    public bool Update(T entity)
    {
        _context.Set<T>().Update(entity);
        return _context.SaveChanges() > 0;
    }

    public bool Remove(T entity)
    {
        _context.Set<T>().Remove(entity);
        return _context.SaveChanges() > 0;
    }
}