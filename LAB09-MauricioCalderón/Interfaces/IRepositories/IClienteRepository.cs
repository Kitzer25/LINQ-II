using LAB08_MauricioCalderón.DTO_s.Operations.Read;
using LAB08_MauricioCalderón.Models;

namespace LAB08_MauricioCalderón.Interfaces.IRepositories;

public interface IClienteRepository : IGRepository<Client>
{
    Task<IEnumerable<ClienteReadDTO>> GetClientsByName(string nombre, CancellationToken ct = default);
    Task<IEnumerable<ClientTotalCountProductsReadDTO>> GetClientWithProductCount(CancellationToken ct = default);
}