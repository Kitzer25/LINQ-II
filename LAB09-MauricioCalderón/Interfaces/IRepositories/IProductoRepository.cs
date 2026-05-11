using LAB08_MauricioCalderón.Models;

namespace LAB08_MauricioCalderón.Interfaces.IRepositories;

public interface IProductoRepository : IGRepository<Product>
{
    Task<IEnumerable<Product>> GetProductsByValue(decimal price, CancellationToken ct = default);
    Task<Product?> GetExpensivePrice(CancellationToken ct = default);
    Task<decimal> GetAverageProducts(CancellationToken ct = default);
    Task<IEnumerable<Product>> GetProductsNoDescriptions(CancellationToken ct = default);
}