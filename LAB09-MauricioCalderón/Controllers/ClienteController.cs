using LAB08_MauricioCalderón.DTO_s.Operations.Create;
using LAB08_MauricioCalderón.DTO_s.Operations.Read;
using LAB08_MauricioCalderón.Interfaces.IServices;
using LAB08_MauricioCalderón.Models;

namespace LAB08_MauricioCalderón.Controllers;

using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class ClientesController : ControllerBase
{
    private readonly IClienteService _service;

    public ClientesController(IClienteService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll(CancellationToken ct)
    {
        var result = await _service.GetAllAsync(ct);

        return Ok(result);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id, CancellationToken ct)
    {
        var result = await _service.GetByIdAsync(id, ct);

        return StatusCode(result.StatusCode, result);
    }

    [HttpPost]
    public async Task<IActionResult> Create(
        [FromBody] ClienteCreateDTO dto,
        CancellationToken ct)
    {
        var result = await _service.AddAsync(dto, ct);

        return StatusCode(result.StatusCode, result);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(
        int id,
        [FromBody] ClienteUpdateDTO dto,
        CancellationToken ct)
    {
        var result = await _service.UpdateAsync(id, dto, ct);

        return StatusCode(result.StatusCode, result);
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(
        [FromBody] Client entity,
        CancellationToken ct)
    {
        var result = await _service.DeleteAsync(entity, ct);

        return StatusCode(result.StatusCode, result);
    }

    [HttpGet("by-name")]
    public async Task<IActionResult> GetClientsByName(
        [FromQuery] string nombre,
        CancellationToken ct)
    {
        var result = await _service.GetClientsByName(nombre, ct);

        return Ok(result);
    }
}