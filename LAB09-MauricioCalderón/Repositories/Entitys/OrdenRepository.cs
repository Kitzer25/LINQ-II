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
    
    public async Task<OrdersByClientDTO?> GetMoreOrdersByClient(CancellationToken ct = default)
    {
        return await DbSet.AsNoTracking()
            .GroupBy(o => o.ClientId)
            .Select(g => new OrdersByClientDTO
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
    public async Task<IEnumerable<DetallesOrdenIncludeReadDTO>> GetOrdersAndProducts(CancellationToken ct = default)
    {
        return await DbSet.AsNoTracking()
            .Include(od => od.Orderdetails)
            .ThenInclude(od => od.Product)
            .Select(o => new DetallesOrdenIncludeReadDTO
            {
                OrderId = o.OrderId,
                OrderDate = o.OrderDate,
                Products = o.Orderdetails.Select(od => new DetallesOrdenProductoReadDTO
                {
                    ProductName = od.Product.Name,
                    Price = od.Product.Price,
                    Quantity = od.Quantity
                }).ToList()
            }).ToListAsync(ct);
    }

    public async Task<IEnumerable<ClientOrderReadDTO>> GetClientOrderList(
        CancellationToken ct = default)
    {
        return await _context.Clients.AsNoTracking()
            .Select(c => new ClientOrderReadDTO
            {
                ClientName = c.Name,
                ClientOrders = c.Orders
                    .Select(o => new OrderClientReadDTO
                    {
                        OrderId = o.OrderId,
                        OrderDate = o.OrderDate
                    }).ToList()
            }).ToListAsync(ct);
    }
    
    public async Task<List<Order>> GetClientWithOrders(CancellationToken ct = default)
    {
        return await DbSet.AsNoTracking()
            .Include(o => o.Orderdetails)
            .ThenInclude(od => od.Product)
            .ToListAsync(ct);
    }

    public async Task<IEnumerable<SalesByClientDTO>> GetSalesByClient(
        CancellationToken ct = default)
    {
        return await DbSet
            .AsNoTracking()
            .GroupBy(o => new 
            { 
                o.ClientId, 
                o.Client.Name 
            })
            .Select(g => new SalesByClientDTO
            {
                ClientName = g.Key.Name,
                TotalSales = g.Sum(o => o.Orderdetails
                    .Sum(od => od.Quantity * od.Product.Price))
            })
            .OrderByDescending(x => x.TotalSales)
            .ToListAsync(ct);
    }
}