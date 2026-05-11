using LAB08_MauricioCalderón.DTO_s.Operations.Create;
using LAB08_MauricioCalderón.DTO_s.Operations.Read;
using LAB08_MauricioCalderón.Models;

namespace LAB08_MauricioCalderón.Interfaces.IServices;

public interface IDetallesOrdenService :
    IGService<
        Orderdetail,
        DetalleOrdenReadDTO,
        DetalleOrdenCreateDTO,
        DetalleOrdenUpdateDTO>
{
    Task<List<ProductQuantityReadDTO>> GetProductosDetails(int id, CancellationToken ct = default);
    Task<int> GetProductsCount(int id, CancellationToken ct = default);
    Task<List<ProductQuantityReadDTO>> GetProductsAndQuantitys(CancellationToken ct = default);
    Task<List<string>> GetClientsByProducts(int id, CancellationToken ct = default);
}