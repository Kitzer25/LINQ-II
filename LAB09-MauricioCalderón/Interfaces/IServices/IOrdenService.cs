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
    Task<object?> GetMoreOrdersByClient(CancellationToken ct = default);
    Task<List<string>> GetClientsByProduct(int clientId, CancellationToken ct = default);
}