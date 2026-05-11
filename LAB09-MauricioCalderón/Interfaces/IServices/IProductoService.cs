using LAB08_MauricioCalderón.DTO_s.Operations.Create;
using LAB08_MauricioCalderón.DTO_s.Operations.Read;
using LAB08_MauricioCalderón.Models;

namespace LAB08_MauricioCalderón.Interfaces.IServices;

public interface IProductoService :
    IGService<
        Product,
        ProductoReadDTO,
        ProductoCreateDTO,
        ProductoUpdateDTO>
{
    Task<IEnumerable<ProductoReadDTO>> GetProductsByValue(decimal price, CancellationToken ct = default);
    Task<ProductoReadDTO?> GetExpensivePrice(CancellationToken ct = default);
    Task<decimal> GetAverageProducts(CancellationToken ct = default);
    Task<IEnumerable<ProductoReadDTO>> GetProductsNoDescriptions(CancellationToken ct = default);
}