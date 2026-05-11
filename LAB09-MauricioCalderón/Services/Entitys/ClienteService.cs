using AutoMapper;
using LAB08_MauricioCalderón.DTO_s.Operations.Create;
using LAB08_MauricioCalderón.DTO_s.Operations.Read;
using LAB08_MauricioCalderón.Interfaces;
using LAB08_MauricioCalderón.Interfaces.IServices;
using LAB08_MauricioCalderón.Models;
using LAB08_MauricioCalderón.Records;

namespace LAB08_MauricioCalderón.Services.Entitys;

public class ClienteService : IClienteService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public ClienteService(
        IUnitOfWork unitOfWork,
        IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<IEnumerable<ClienteReadDTO>> GetAllAsync(
        CancellationToken ct = default)
    {
        var clients = await _unitOfWork
            .ClienteRepo
            .GetAllAsync(ct);

        return _mapper.Map<IEnumerable<ClienteReadDTO>>(clients);
    }

    public async Task<Result<ClienteReadDTO>> GetByIdAsync<TKey>(
        TKey id,
        CancellationToken ct = default)
    {
        var client = await _unitOfWork
            .ClienteRepo
            .GetByIdAsync(id, ct);

        if (client is null)
            return Result<ClienteReadDTO>
                .Failure("Cliente no encontrado");

        var dto = _mapper.Map<ClienteReadDTO>(client);

        return Result<ClienteReadDTO>.Ok(dto);
    }

    public async Task<Result<ClienteCreateDTO>> AddAsync(
        ClienteCreateDTO create,
        CancellationToken ct = default)
    {
        var entity = _mapper.Map<Client>(create);
        
        await _unitOfWork
            .ClienteRepo
            .CreateAsync(entity, ct);


        return Result<ClienteCreateDTO>.Created(create);
    }

    public async Task<Result<ClienteUpdateDTO>> UpdateAsync<TKey>(
        TKey id,
        ClienteUpdateDTO update,
        CancellationToken ct = default)
    {
        var entity = _mapper.Map<Client>(update);
        
        await _unitOfWork.ClienteRepo.UpdateAsync(entity, ct);

        return Result<ClienteUpdateDTO>.Ok(update);
    }
    
    public async Task<Result<bool>> DeleteAsync<TKey>(
        TKey id,
        CancellationToken ct = default)
    {
        var entity = await _unitOfWork.ClienteRepo.GetByIdAsync(id, ct);
        
        if (entity is null) throw new KeyNotFoundException("Objeto no encontrado");
        
        await _unitOfWork
            .ClienteRepo
            .DeleteAsync(entity, ct);

        return Result<bool>.Ok(true);
    }
    
    
    public async Task<IEnumerable<ClienteReadDTO>> GetClientsByName(
        string nombre,
        CancellationToken ct = default)
    {
        var clients = await _unitOfWork
            .ClienteRepo
            .GetClientsByName(nombre, ct);

        return _mapper.Map<IEnumerable<ClienteReadDTO>>(clients);
    }
}