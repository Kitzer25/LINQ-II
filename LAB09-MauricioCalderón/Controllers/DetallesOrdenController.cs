using LAB08_MauricioCalderón.DTO_s.Operations.Create;
using LAB08_MauricioCalderón.DTO_s.Operations.Read;
using LAB08_MauricioCalderón.Interfaces.IServices;
using LAB08_MauricioCalderón.Models;

namespace LAB08_MauricioCalderón.Controllers;

using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class DetallesOrdenController : ControllerBase
{
    private readonly IDetallesOrdenService _service;

    public DetallesOrdenController(IDetallesOrdenService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll(CancellationToken ct)
    {
        var result = await _service.GetAllAsync(ct);

        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(
        [FromRoute] int id, CancellationToken ct)
    {
        var result = await _service.GetByIdAsync(id, ct);

        return StatusCode(result.StatusCode, result);
    }

    [HttpPost]
    public async Task<IActionResult> Create(
        [FromBody] DetalleOrdenCreateDTO dto,
        CancellationToken ct)
    {
        var result = await _service.AddAsync(dto, ct);

        return CreatedAtAction(
            nameof(GetById),
            new { id = result.Data },
            result);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(
        int id,
        [FromBody] DetalleOrdenUpdateDTO dto,
        CancellationToken ct)
    {
        var result = await _service.UpdateAsync(id, dto, ct);

        return StatusCode(result.StatusCode, result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(
        int id,
        CancellationToken ct)
    {
        var result = await _service.DeleteAsync(id, ct);

        return StatusCode(result.StatusCode, result);
    }

    [HttpGet("{id:int}/products")]
    public async Task<IActionResult> GetProductosDetails(
        int id,
        CancellationToken ct)
    {
        var result = await _service.GetProductosDetails(id, ct);

        return Ok(result);
    }

    [HttpGet("{id:int}/products/count")]
    public async Task<IActionResult> GetProductsCount(
        int id,
        CancellationToken ct)
    {
        var result = await _service.GetProductsCount(id, ct);

        return Ok(result);
    }

    [HttpGet("products/quantities")]
    public async Task<IActionResult> GetProductsAndQuantitys(
        CancellationToken ct)
    {
        var result = await _service.GetProductsAndQuantitys(ct);

        return Ok(result);
    }

    [HttpGet("{id:int}/products/clients")]
    public async Task<IActionResult> GetClientsByProducts(
        int id,
        CancellationToken ct)
    {
        var result = await _service.GetClientsByProducts(id, ct);

        return Ok(result);
    }
}