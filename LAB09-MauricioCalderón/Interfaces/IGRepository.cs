namespace LAB08_MauricioCalderón.Interfaces;

public interface IGRepository<T>
    where T : class
{
    Task<IEnumerable<T>> GetAllAsync(CancellationToken ct = default);
    Task<T?> GetByIdAsync<TKey>(TKey id, CancellationToken ct = default);
    Task CreateAsync(T entity, CancellationToken ct = default);
    Task UpdateAsync(T entity, CancellationToken ct = default);
    Task DeleteAsync(T entity, CancellationToken ct = default);
}