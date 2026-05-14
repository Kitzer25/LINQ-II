using LAB08_MauricioCalderón.DTO_s.Operations.Read;
using LAB08_MauricioCalderón.Interfaces.IRepositories;
using LAB08_MauricioCalderón.Models;
using Microsoft.EntityFrameworkCore;

namespace LAB08_MauricioCalderón.Repositories.Entitys;

public class DetallesOrdenRepository : 
    GRepository<Orderdetail>,
    IDetallesOrdenRepository
{
    public DetallesOrdenRepository(dbContextLINQ dbContext) : base(dbContext)
    { }

    public async Task<List<Orderdetail>> GetProductosDetails(int id, CancellationToken ct = default)
    {
        return await DbSet.AsNoTracking()
            .Where(o => o.OrderId == id)
            .Include(x => x.Product)
            .ToListAsync(ct);
    }

    public async Task<int> GetProductsCount(int id, CancellationToken ct = default)
    {
        int quantity = await DbSet.AsNoTracking()
            .Where(o => o.OrderId == id)
            .Select(o => o.Quantity)
            .SumAsync(ct);
        
        return quantity;
    }

    public async Task<List<Orderdetail>> GetProductsAndQuantitys(CancellationToken ct = default)
    {
        return await DbSet.AsNoTracking()
            .Include(x => x.Product)
            .ToListAsync(ct);
    }

    public async Task<List<string>> GetProductsByClient(int productId, CancellationToken ct = default)
    {
        return await DbSet.AsNoTracking()
            .Where(od => od.ProductId == productId)
            .Select(od => od.Order.Client.Name)
            .Distinct()
            .ToListAsync(ct);
    }
}