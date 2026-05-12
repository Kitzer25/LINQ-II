using System.Security.Principal;
using LAB08_MauricioCalderón.DTO_s.Operations.Read;
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
    
    //Implementación Nueva
    public async Task<List<Order>> GetClientWithOrders(CancellationToken ct = default)
    {
        return await DbSet.AsNoTracking()
            .Include(o => o.Orderdetails)
            .ThenInclude(od => od.Product)
            .ToListAsync(ct);
    }

    public async Task<IEnumerable<SalesByClientDTO> GetSalesByCLient(CancellationToken ct = default)
    {
        var sales = await dbContextLINQ.Order
            .AsNoTracking()
            .Include(o => o.Client)
            .Include(o => o.Orderdetails)
            .ThenInclude(od => od.Product)
            .GroupBy(o => new
            {
                o.ClientId,
                o.Client.Name
            })
            .Select(group => new SalesByClientDTO
            {
                ClientName = group.Key.Name,
                TotalSales = group
                    .SelectMany(o => o.OrderDetails)
                    .Sum(d => d.Quantity * d.Product.Price)
            })
            .OrderByDescending(x => x.TotalSales)
            .ToListAsync();
    }
}