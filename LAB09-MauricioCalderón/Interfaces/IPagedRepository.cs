using System.Linq.Expressions;

namespace LAB08_MauricioCalderón.Interfaces;

public interface IPagedRepository<T> 
    where T : class
{
    Task<int> CountAsync(CancellationToken ct = default);
    Task<IEnumerable<T>> GetPaged<TKey>(
        int page,
        int pageSize,
        Expression<Func<T, bool>> orderBy,
        bool ascending = true,
        CancellationToken ct = default
    );
}