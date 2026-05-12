using LAB08_MauricioCalderón.Interfaces;
using LAB08_MauricioCalderón.Models;
using Microsoft.EntityFrameworkCore;

namespace LAB08_MauricioCalderón.Repositories;

public class GRepository<T> : IGRepository<T>
    where T : class
{
    protected readonly dbContextLINQ _context;
    protected readonly DbSet<T> DbSet;

    public GRepository(dbContextLINQ context)
    {
        _context = context;
        DbSet = context.Set<T>();
    }


    public async Task<IEnumerable<T>> GetAllAsync(CancellationToken ct = default)
    {
        var data = await DbSet
            .AsNoTracking()
            .ToListAsync(ct);
        
        return data;
    }


    public async Task<T?> GetByIdAsync<TKey>(TKey id, CancellationToken ct = default)
    {
        var data = await DbSet.FindAsync(id, ct);
            
        return data;
    }

    public async Task CreateAsync(T entity, CancellationToken ct = default)
    {
        await DbSet.AddAsync(entity);
        await _context.SaveChangesAsync(ct); 
    }

    public async Task UpdateAsync(T entity, CancellationToken ct = default)
    {
        DbSet.Update(entity);
        await _context.SaveChangesAsync(ct);
    }

    public async Task DeleteAsync(T entity, CancellationToken ct = default)
    {
        DbSet.Remove(entity);
        await _context.SaveChangesAsync(ct);
    }
}