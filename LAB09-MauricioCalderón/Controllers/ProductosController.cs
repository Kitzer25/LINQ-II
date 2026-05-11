using LAB08_MauricioCalderón.DTO_s.Operations.Create;
using LAB08_MauricioCalderón.DTO_s.Operations.Read;
using LAB08_MauricioCalderón.Interfaces.IServices;
using LAB08_MauricioCalderón.Models;

namespace LAB08_MauricioCalderón.Controllers;

using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class ProductosController : ControllerBase
{
    private readonly IProductoService _service;

    public ProductosController(IProductoService service)
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
        [FromBody] ProductoCreateDTO dto,
        CancellationToken ct)
    {
        var result = await _service.AddAsync(dto, ct);

        return StatusCode(result.StatusCode, result);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(
        int id,
        [FromBody] ProductoUpdateDTO dto,
        CancellationToken ct)
    {
        var result = await _service.UpdateAsync(id, dto, ct);

        return StatusCode(result.StatusCode, result);
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(
        [FromBody] Product entity,
        CancellationToken ct)
    {
        var result = await _service.DeleteAsync(entity, ct);

        return StatusCode(result.StatusCode, result);
    }

    [HttpGet("by-price")]
    public async Task<IActionResult> GetProductsByValue(
        [FromQuery] decimal price,
        CancellationToken ct)
    {
        var result = await _service.GetProductsByValue(price, ct);

        return Ok(result);
    }

    [HttpGet("expensive")]
    public async Task<IActionResult> GetExpensivePrice(
        CancellationToken ct)
    {
        var result = await _service.GetExpensivePrice(ct);

        return Ok(result);
    }

    [HttpGet("average")]
    public async Task<IActionResult> GetAverageProducts(
        CancellationToken ct)
    {
        var result = await _service.GetAverageProducts(ct);

        return Ok(result);
    }

    [HttpGet("without-description")]
    public async Task<IActionResult> GetProductsNoDescriptions(
        CancellationToken ct)
    {
        var result = await _service.GetProductsNoDescriptions(ct);

        return Ok(result);
    }
}