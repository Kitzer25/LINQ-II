using AutoMapper;
using LAB08_MauricioCalderón.DTO_s.Operations.Create;
using LAB08_MauricioCalderón.DTO_s.Operations.Read;
using LAB08_MauricioCalderón.Interfaces;
using LAB08_MauricioCalderón.Interfaces.IServices;
using LAB08_MauricioCalderón.Models;
using LAB08_MauricioCalderón.Records;

namespace LAB08_MauricioCalderón.Services.Entitys;

public class ProductoService : IProductoService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public ProductoService(
        IUnitOfWork unitOfWork,
        IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<IEnumerable<ProductoReadDTO>> GetAllAsync(
        CancellationToken ct = default)
    {
        var products = await _unitOfWork.ProductoRepo.GetAllAsync(ct);

        return _mapper.Map<IEnumerable<ProductoReadDTO>>(products);
    }

    public async Task<Result<ProductoReadDTO>> GetByIdAsync<TKey>(
        TKey id,
        CancellationToken ct = default)
    {
        var product = await _unitOfWork.ProductoRepo.GetByIdAsync(id, ct);

        if (product is null)
            return Result<ProductoReadDTO>.Failure("Producto no encontrado");

        var dto = _mapper.Map<ProductoReadDTO>(product);

        return Result<ProductoReadDTO>.Ok(dto);
    }

    public async Task<Result<ProductoCreateDTO>> AddAsync(
        ProductoCreateDTO create,
        CancellationToken ct = default)
    {
        var entity = _mapper.Map<Product>(create);
        
        await _unitOfWork.ProductoRepo.CreateAsync(entity, ct);

        return Result<ProductoCreateDTO>.Created(create);
    }

    public async Task<Result<ProductoUpdateDTO>> UpdateAsync<TKey>(
        TKey id,
        ProductoUpdateDTO update,
        CancellationToken ct = default)
    {
        var entity = _mapper.Map<Product>(update);
        
        await _unitOfWork.ProductoRepo.UpdateAsync(entity, ct);

        return Result<ProductoUpdateDTO>.Ok(update);
    }

    public async Task<Result<bool>> DeleteAsync<TKey>(
        TKey id,
        CancellationToken ct = default)
    {
        var entity = await  _unitOfWork.ProductoRepo.GetByIdAsync(id, ct);
        
        if (entity is null) throw new KeyNotFoundException("Producto no encontrado");
        
        await _unitOfWork.ProductoRepo.DeleteAsync(entity, ct);

        return Result<bool>.Ok(true);
    }
    

    public async Task<IEnumerable<ProductoReadDTO>> GetProductsByValue(
        decimal price,
        CancellationToken ct = default)
    {
        var products = await _unitOfWork.ProductoRepo.GetProductsByValue(price, ct);

        return _mapper.Map<IEnumerable<ProductoReadDTO>>(products);
    }

    public async Task<ProductoReadDTO?> GetExpensivePrice(
        CancellationToken ct = default)
    {
        var product = await _unitOfWork.ProductoRepo.GetExpensivePrice(ct);

        if (product is null)
            return null;

        return _mapper.Map<ProductoReadDTO>(product);
    }

    public async Task<decimal> GetAverageProducts(
        CancellationToken ct = default)
    {
        return await _unitOfWork.ProductoRepo.GetAverageProducts(ct);
    }

    public async Task<IEnumerable<ProductoReadDTO>> GetProductsNoDescriptions(
        CancellationToken ct = default)
    {
        var products = await _unitOfWork.ProductoRepo.GetProductsNoDescriptions(ct);

        return _mapper.Map<IEnumerable<ProductoReadDTO>>(products);
    }
}