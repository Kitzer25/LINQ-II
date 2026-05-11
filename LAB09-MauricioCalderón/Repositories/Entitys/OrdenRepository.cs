using LAB08_MauricioCalderón.Interfaces.IRepositories;
using LAB08_MauricioCalderón.Models;
using Microsoft.EntityFrameworkCore;

namespace LAB08_MauricioCalderón.Repositories.Entitys;

public class OrdenRepository :
    GRepository<Order>,
    IOrdenRepository
{
    public OrdenRepository(dbContextLINQ context) : base(context)
    { }


    public async Task<IEnumerable<Order>> GetOrderByDate(DateTime date, CancellationToken ct = default)
    {
        return await DbSet.AsNoTracking()
            .Where(od => od.OrderDate > date)
            .OrderBy(od => od.OrderDate)
            .ToListAsync(ct);
    }
    
    public async Task<object?> GetMoreOrdersByClient(CancellationToken ct = default)
    {
        return await DbSet.AsNoTracking()
            .GroupBy(o => o.ClientId)
            .Select(g => new
            {
                ClientId = g.Key,
                TotalOrders = g.Count()
            })
            .OrderByDescending(g => g.TotalOrders)
            .FirstOrDefaultAsync(ct);
    }
    
    public async Task<List<string>> GetClientsByProduct(int clientId, CancellationToken ct = default)
    {
        return await DbSet.AsNoTracking()
            .Where(o => o.ClientId == clientId)
            .SelectMany(od => od.Orderdetails)
            .Select(od => od.Product.Name)
            .Distinct()
            .ToListAsync(ct);
    }
}