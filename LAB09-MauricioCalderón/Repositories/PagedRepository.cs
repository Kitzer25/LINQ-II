using System.Linq.Expressions;
using LAB08_MauricioCalderón.Interfaces;
using LAB08_MauricioCalderón.Models;
using Microsoft.EntityFrameworkCore;

namespace LAB08_MauricioCalderón.Repositories;

public class PagedRepository<T> : IPagedRepository<T>
    where T : class
{
    private readonly DbSet<T> _dbSet;

    public PagedRepository(dbContextLINQ context)
    {
        _dbSet = context.Set<T>();
    }


    public async Task<int> CountAsync(CancellationToken ct = default)
    {
        return await _dbSet.CountAsync(ct);
    }

    public async Task<IEnumerable<T>> GetPaged<TKey>(
        int page,
        int pageSize,
        Expression<Func<T, bool>> orderBy,
        bool ascending = true,
        CancellationToken ct = default)
    {
        var query = _dbSet.AsNoTracking();

        query = ascending
            ? query.OrderBy(orderBy)
            : query.OrderByDescending(orderBy);

        return await query
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync(ct);
    }
}