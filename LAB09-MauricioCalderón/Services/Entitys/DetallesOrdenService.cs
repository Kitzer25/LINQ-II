using AutoMapper;
using LAB08_MauricioCalderón.DTO_s.Operations.Create;
using LAB08_MauricioCalderón.DTO_s.Operations.Read;
using LAB08_MauricioCalderón.Interfaces;
using LAB08_MauricioCalderón.Interfaces.IServices;
using LAB08_MauricioCalderón.Models;
using LAB08_MauricioCalderón.Records;

namespace LAB08_MauricioCalderón.Services.Entitys;

public class DetallesOrdenService : IDetallesOrdenService
{
    private readonly IUnitOfWork _repository;
    private readonly IMapper _mapper;

    public DetallesOrdenService(
        IUnitOfWork repository,
        IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
    

    public async Task<IEnumerable<DetalleOrdenReadDTO>> GetAllAsync(
        CancellationToken ct = default)
    {
        var details = await _repository.DetallesOrdenRepo.GetAllAsync(ct);

        return _mapper.Map<IEnumerable<DetalleOrdenReadDTO>>(details);
    }

    public async Task<Result<DetalleOrdenReadDTO>> GetByIdAsync<TKey>(
        TKey id,
        CancellationToken ct = default)
    {
        var detail = await _repository.DetallesOrdenRepo.GetByIdAsync(id, ct);

        if (detail is null)
            return Result<DetalleOrdenReadDTO>
                .Failure("Detalle de orden no encontrado");

        var dto = _mapper.Map<DetalleOrdenReadDTO>(detail);

        return Result<DetalleOrdenReadDTO>.Ok(dto);
    }

    public async Task<Result<DetalleOrdenCreateDTO>> AddAsync(
        DetalleOrdenCreateDTO create,
        CancellationToken ct = default)
    {
        var dto = _mapper.Map<Orderdetail>(create);
        
        await _repository.DetallesOrdenRepo.CreateAsync(dto, ct);

        return Result<DetalleOrdenCreateDTO>.Created(create);
    }

    public async Task<Result<DetalleOrdenUpdateDTO>> UpdateAsync<TKey>(
        TKey id,
        DetalleOrdenUpdateDTO update,
        CancellationToken ct = default)
    {
        var entity = _mapper.Map<Orderdetail>(update);
        
        await _repository.DetallesOrdenRepo.UpdateAsync(entity, ct);

        return Result<DetalleOrdenUpdateDTO>.Ok(update);
    }

    public async Task<Result<bool>> DeleteAsync<TKey>(
        TKey id,
        CancellationToken ct = default)
    {
        var entity =  await _repository.DetallesOrdenRepo.GetByIdAsync(id, ct);
        
        if (entity is null) throw new  KeyNotFoundException("Objeto no encontrado");
        
        await _repository.DetallesOrdenRepo.DeleteAsync(entity, ct);

        return Result<bool>.Ok(true);
    }
    

    public async Task<List<ProductQuantityReadDTO>> GetProductosDetails(
        int id,
        CancellationToken ct = default)
    {
        var details = await _repository.DetallesOrdenRepo.GetProductosDetails(id, ct);

        return _mapper.Map<List<ProductQuantityReadDTO>>(details);
    }

    public async Task<int> GetProductsCount(
        int id,
        CancellationToken ct = default)
    {
        return await _repository.DetallesOrdenRepo.GetProductsCount(id, ct);
    }

    public async Task<List<ProductQuantityReadDTO>> GetProductsAndQuantitys(
        CancellationToken ct = default)
    {
        var details = await _repository.DetallesOrdenRepo.GetProductsAndQuantitys(ct);

        return _mapper.Map<List<ProductQuantityReadDTO>>(details);
    }

    public async Task<List<string>> GetClientsByProducts(
        int id,
        CancellationToken ct = default)
    {
        return await _repository.DetallesOrdenRepo.GetProductsByClient(id, ct);
    }
}