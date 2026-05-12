using LAB08_MauricioCalderón.DTO_s.Operations.Read;
using LAB08_MauricioCalderón.Models;

namespace LAB08_MauricioCalderón.Interfaces.IRepositories;

public interface IOrdenRepository : IGRepository<Order>
{
    Task<IEnumerable<Order>> GetOrderByDate(DateTime date, CancellationToken ct = default);
    Task<OrdersByClientDTO?> GetMoreOrdersByClient(CancellationToken ct = default);
    Task<List<string>> GetClientsByProduct(int clientId, CancellationToken ct = default);
    Task<List<Order>> GetClientWithOrders(CancellationToken ct = default);
    Task<IEnumerable<SalesByClientDTO>> GetSalesByClient(CancellationToken ct = default);
}