using LAB08_MauricioCalderón.DTO_s.Operations.Create;
using LAB08_MauricioCalderón.DTO_s.Operations.Read;
using LAB08_MauricioCalderón.Interfaces.IServices;
using LAB08_MauricioCalderón.Models;

namespace LAB08_MauricioCalderón.Controllers;

using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class OrdenesController : ControllerBase
{
    private readonly IOrdenService _service;

    public OrdenesController(IOrdenService service)
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
        [FromBody] OrdenCreateDTO dto,
        CancellationToken ct)
    {
        var result = await _service.AddAsync(dto, ct);

        return StatusCode(result.StatusCode, result);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(
        int id,
        [FromBody] OrdenUpdateDTO dto,
        CancellationToken ct)
    {
        var result = await _service.UpdateAsync(id, dto, ct);

        return StatusCode(result.StatusCode, result);
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(
        [FromBody] Order entity,
        CancellationToken ct)
    {
        var result = await _service.DeleteAsync(entity, ct);

        return StatusCode(result.StatusCode, result);
    }

    [HttpGet("by-date")]
    public async Task<IActionResult> GetOrderByDate(
        [FromQuery] string date,
        CancellationToken ct)
    {
        var result = await _service.GetOrderByDate(date, ct);

        return Ok(result);
    }

    [HttpGet("more-orders-client")]
    public async Task<IActionResult> GetMoreOrdersByClient(
        CancellationToken ct)
    {
        var result = await _service.GetMoreOrdersByClient(ct);

        return Ok(result);
    }

    [HttpGet("clients-products/{clientId:int}")]
    public async Task<IActionResult> GetClientsByProduct(
        int clientId,
        CancellationToken ct)
    {
        var result = await _service.GetClientsByProduct(clientId, ct);

        return Ok(result);
    }
}