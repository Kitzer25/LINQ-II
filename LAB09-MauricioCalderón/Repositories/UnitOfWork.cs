using LAB08_MauricioCalderón.Interfaces;
using LAB08_MauricioCalderón.Interfaces.IRepositories;
using LAB08_MauricioCalderón.Models;
using LAB08_MauricioCalderón.Repositories.Entitys;

namespace LAB08_MauricioCalderón.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly Dictionary<Type, object> _repositories;
    private readonly dbContextLINQ _context;

    public UnitOfWork(dbContextLINQ context)
    {
        _context = context;
        _repositories = new Dictionary<Type, object>();

        //Implementación de Repositorios
        ClienteRepo = new ClienteRepository(_context);
        DetallesOrdenRepo = new DetallesOrdenRepository(_context);
        OrdenRepo = new OrdenRepository(_context);
        ProductoRepo = new ProductoRepository(_context);
    }
    //Repositorios Específicos
    public IClienteRepository ClienteRepo { get; }
    public IDetallesOrdenRepository DetallesOrdenRepo { get; }
    public IOrdenRepository OrdenRepo { get; }
    public IProductoRepository ProductoRepo { get; }
    
    
    //Implementación de Dictionary vs. Hastable
    public IGRepository<T> Repository<T>() where T : class
    {
        var type = typeof(T);

        if (_repositories.TryGetValue(type, out var repository))
        {
            return (IGRepository<T>)repository;
        }

        var repositoryInstance = new GRepository<T>(_context);
        
        _repositories.Add(type, repositoryInstance);

        return repositoryInstance;
    }

    public async Task<int> SaveAsync(CancellationToken ct = default)
    {
        return await _context.SaveChangesAsync(ct);
    }
    
    public void Dispose()
    {
        _context.Dispose();
    }
}
