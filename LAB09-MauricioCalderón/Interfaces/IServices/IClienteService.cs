using LAB08_MauricioCalderón.DTO_s.Operations.Create;
using LAB08_MauricioCalderón.DTO_s.Operations.Read;
using LAB08_MauricioCalderón.Models;

namespace LAB08_MauricioCalderón.Interfaces.IServices;

public interface IClienteService :
    IGService<
        Client,
        ClienteReadDTO,
        ClienteCreateDTO,
        ClienteUpdateDTO>
{
    Task<IEnumerable<ClienteReadDTO>> GetClientsByName(string nombre, CancellationToken ct = default);
}