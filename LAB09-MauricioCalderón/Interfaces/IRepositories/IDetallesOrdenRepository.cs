using LAB08_MauricioCalderón.DTO_s.Operations.Read;
using LAB08_MauricioCalderón.Models;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

namespace LAB08_MauricioCalderón.Interfaces.IRepositories;

public interface IDetallesOrdenRepository : IGRepository<Orderdetail>
{
    Task<List<ProductQuantityReadDTO>> GetProductosDetails(int id, CancellationToken ct = default);
    Task<int> GetProductsCount(int id, CancellationToken ct = default);
    Task<List<ProductQuantityReadDTO>> GetProductsAndQuantitys(CancellationToken ct = default);
    Task<List<string>> GetProductsByClient(int productId, CancellationToken ct = default);
}