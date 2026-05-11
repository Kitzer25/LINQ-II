using LAB08_MauricioCalderón.Interfaces.IRepositories;

namespace LAB08_MauricioCalderón.Interfaces;

public interface IUnitOfWork : IDisposable
{
    // Repositorios
    IClienteRepository ClienteRepo { get; } 
    IDetallesOrdenRepository DetallesOrdenRepo { get; }
    IOrdenRepository OrdenRepo { get; }
    IProductoRepository ProductoRepo { get; }
    
    protected IGRepository<T> Repository<T>() where T : class;
    Task<int> SaveAsync(CancellationToken ct = default);
}