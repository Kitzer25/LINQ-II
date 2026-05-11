using LAB08_MauricioCalderón.Interfaces;
using LAB08_MauricioCalderón.Interfaces.IRepositories;
using LAB08_MauricioCalderón.Models;
using Microsoft.EntityFrameworkCore;

namespace LAB08_MauricioCalderón.Repositories.Entitys;

public class ProductoRepository : 
    GRepository<Product>,
    IProductoRepository
{
    public ProductoRepository(dbContextLINQ dbContext) : base(dbContext) 
    { }

    public async Task<IEnumerable<Product>> GetProductsByValue(decimal price, CancellationToken ct = default)
    {
        IEnumerable<Product> products = await DbSet
            .Where(p => p.Price > price)
            .ToListAsync(ct);
        
        return products;
    }
    

    public async Task<Product?> GetExpensivePrice(CancellationToken ct = default)
    {
        Product? product = await DbSet
            .OrderByDescending(p => p.Price)
            .FirstOrDefaultAsync(ct);
        
        return product;
    }

    public async Task<decimal> GetAverageProducts(CancellationToken ct = default)
    {
        decimal average = await DbSet
            .AverageAsync(p => p.Price, ct);
        
        return average;
    }

    public async Task<IEnumerable<Product>> GetProductsNoDescriptions(CancellationToken ct = default)
    {
        IEnumerable<Product> products = await DbSet
            .Where(p => p.Description == null)
            .ToListAsync(ct);
        
        return products;
    }
}