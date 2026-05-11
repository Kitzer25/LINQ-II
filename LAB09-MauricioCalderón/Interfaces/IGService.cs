using LAB08_MauricioCalderón.Records;

namespace LAB08_MauricioCalderón.Interfaces;

public interface IGService<T, TRead, TCreate, TUpdate>
    where T : class 
    where TRead : class
    where TCreate : class
    where TUpdate : class
{
    Task<IEnumerable<TRead>> GetAllAsync(CancellationToken ct = default);
    Task<Result<TRead>> GetByIdAsync<TKey>(TKey id, CancellationToken ct = default);
    Task<Result<TCreate>> AddAsync(TCreate create, CancellationToken ct = default);
    Task<Result<TUpdate>> UpdateAsync<TKey>(TKey id, TUpdate update, CancellationToken ct = default);
    Task<Result<bool>> DeleteAsync<TKey>(TKey id, CancellationToken ct = default);
}