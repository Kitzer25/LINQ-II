using LAB08_MauricioCalderón.DTO_s.Operations.Create;
using LAB08_MauricioCalderón.DTO_s.Operations.Read;
using LAB08_MauricioCalderón.Models;

namespace LAB08_MauricioCalderón.Interfaces.IServices;

public interface IOrdenService :
    IGService<
        Order,
        OrdenReadDTO,
        OrdenCreateDTO,
        OrdenUpdateDTO>
{
    Task<IEnumerable<OrdenReadDTO>> GetOrderByDate(string date, CancellationToken ct = default);
    Task<OrdersByClientDTO?> GetMoreOrdersByClient(CancellationToken ct = default);
    Task<List<string>> GetClientsByProduct(int clientId, CancellationToken ct = default);
    Task<IEnumerable<ClientOrderReadDTO>> GetClientList(CancellationToken ct = default);
    Task<IEnumerable<ClientWithOrdersDTO>> GetClientsWithOrders(CancellationToken ct = default);
    Task<IEnumerable<SalesByClientDTO>> GetSalesByClient(CancellationToken ct = default);
}