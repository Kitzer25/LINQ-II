using System.Globalization;
using AutoMapper;
using LAB08_MauricioCalderón.DTO_s.Operations.Create;
using LAB08_MauricioCalderón.DTO_s.Operations.Read;
using LAB08_MauricioCalderón.Interfaces;
using LAB08_MauricioCalderón.Interfaces.IServices;
using LAB08_MauricioCalderón.Models;
using LAB08_MauricioCalderón.Records;

namespace LAB08_MauricioCalderón.Services.Entitys;

public class OrdenService : IOrdenService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public OrdenService(
        IUnitOfWork unitOfWork,
        IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    
    
    public async Task<IEnumerable<OrdenReadDTO>> GetAllAsync(
        CancellationToken ct = default)
    {
        var orders = await _unitOfWork.OrdenRepo.GetAllAsync(ct);

        return _mapper.Map<IEnumerable<OrdenReadDTO>>(orders);
    }

    public async Task<Result<OrdenReadDTO>> GetByIdAsync<TKey>(
        TKey id,
        CancellationToken ct = default)
    {
        var order = await _unitOfWork.OrdenRepo.GetByIdAsync(id, ct);

        if (order is null)
            return Result<OrdenReadDTO>
                .Failure("Orden no encontrada");

        var dto = _mapper.Map<OrdenReadDTO>(order);

        return Result<OrdenReadDTO>.Ok(dto);
    }


    public async Task<Result<OrdenCreateDTO>> AddAsync(
        OrdenCreateDTO create,
        CancellationToken ct = default)
    {
        var dto = _mapper.Map<Order>(create);
        
        await _unitOfWork.OrdenRepo.CreateAsync(dto, ct);

        return Result<OrdenCreateDTO>.Created(create);
    }

    public async Task<Result<OrdenUpdateDTO>> UpdateAsync<TKey>(
        TKey id,
        OrdenUpdateDTO update,
        CancellationToken ct = default)
    {
        var entity = _mapper.Map<Order>(update);
       
        await _unitOfWork.OrdenRepo.UpdateAsync(entity, ct);

        return Result<OrdenUpdateDTO>.Ok(update);
    }

    public async Task<Result<bool>> DeleteAsync<TKey>(
        TKey id,
        CancellationToken ct = default)
    {
        var entity =  await _unitOfWork.OrdenRepo.GetByIdAsync(id, ct);

        if (entity is null) throw new KeyNotFoundException("Objeto no encontrado");
        
        await _unitOfWork.OrdenRepo.DeleteAsync(entity, ct);

        return Result<bool>.Ok(true);
    }
    
    public async Task<IEnumerable<OrdenReadDTO>> GetOrderByDate(
        string date,
        CancellationToken ct = default)
    {
        string format = "yyyy-MM-dd";

        bool isValidDate = DateTime.TryParseExact(
            date,
            format,
            CultureInfo.InvariantCulture,
            DateTimeStyles.None,
            out DateTime specificDate);

        if (!isValidDate)
            throw new Exception("Formato de fecha inválido");

        var orders = await _unitOfWork
            .OrdenRepo
            .GetOrderByDate(specificDate, ct);

        return _mapper.Map<IEnumerable<OrdenReadDTO>>(orders);
    }

    public async Task<OrdersByClientDTO?> GetMoreOrdersByClient(
        CancellationToken ct = default)
    {
        return await _unitOfWork.OrdenRepo.GetMoreOrdersByClient(ct);
    }
    
    //Implementación
    public async Task<List<string>> GetClientsByProduct(
        int clientId,
        CancellationToken ct = default)
    {
        return await _unitOfWork.OrdenRepo.GetClientsByProduct(clientId, ct);
    }

    public async Task<IEnumerable<ClientOrderReadDTO>> GetClientList(CancellationToken ct = default)
    {
        return await _unitOfWork.OrdenRepo.GetClientOrderList(ct);
    }

    public async Task<IEnumerable<ClientWithOrdersDTO>> GetClientsWithOrders(CancellationToken ct = default)
    {
        List <Order> orders = await _unitOfWork.OrdenRepo.GetClientWithOrders(ct);
        
        return _mapper.Map<List<ClientWithOrdersDTO>>(orders); 
    }

    public async Task<IEnumerable<SalesByClientDTO>> GetSalesByClient(CancellationToken ct = default)
    {
        IEnumerable<SalesByClientDTO> sales = await _unitOfWork.OrdenRepo.GetSalesByClient();

        return sales;
    }
    
    
}