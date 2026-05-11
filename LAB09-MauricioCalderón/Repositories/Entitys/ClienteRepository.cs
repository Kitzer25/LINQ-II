using LAB08_MauricioCalderón.DTO_s.Operations.Read;
using LAB08_MauricioCalderón.Interfaces.IRepositories;
using LAB08_MauricioCalderón.Models;
using Microsoft.EntityFrameworkCore;

namespace LAB08_MauricioCalderón.Repositories.Entitys;

public class ClienteRepository : 
    GRepository<Client>,
    IClienteRepository
{
    public ClienteRepository(dbContextLINQ context) : base(context)
    { }

    public async Task<IEnumerable<ClienteReadDTO>> GetClientsByName(string nombre, CancellationToken ct = default)
    {
        return await DbSet.AsNoTracking()
            .Where(c => c.Name == nombre)
            .Select(c => new ClienteReadDTO
            {
                Name = c.Name,
                Email = c.Email
            })
            .ToListAsync(ct);
    }
}