using AutoMapper;
using ElixirLinePlatform.API.SupplyInventory.Domain.Model.Entities;
using ElixirLinePlatform.API.SupplyInventory.Domain.Services;
using ElixirLinePlatform.API.SupplyInventory.Interfaces.REST.Resources;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace ElixirLinePlatform.API.SupplyInventory.Interfaces.REST.Controllers;

[ApiController]
[Route("api/[controller]")]
[Produces("application/json")]
public class SuppliesController : ControllerBase
{
    private readonly ISupplyService _supplyService;
    private readonly IMapper _mapper;

    public SuppliesController(ISupplyService supplyService, IMapper mapper)
    {
        _supplyService = supplyService;
        _mapper = mapper;
    }

    [HttpGet]
    [SwaggerOperation(
        Summary = "Listar todos los insumos",
        Description = "Obtiene una lista de todos los insumos disponibles",
        Tags = new[] { "Supplies" }
    )]
    public async Task<IActionResult> GetAllAsync()
    {
        var supplies = await _supplyService.ListAsync();
        var resources = _mapper.Map<IEnumerable<Supply>, IEnumerable<SupplyResource>>(supplies);
        
        return Ok(resources);
    }

    [HttpGet("{id}")]
    [SwaggerOperation(
        Summary = "Obtener un insumo por ID",
        Description = "Obtiene un insumo específico por su ID",
        Tags = new[] { "Supplies" }
    )]
    public async Task<IActionResult> GetByIdAsync(int id)
    {
        var result = await _supplyService.FindByIdAsync(id);
        
        if (!result.Success)
            return NotFound(result.Message);
            
        var supplyResource = _mapper.Map<Supply, SupplyResource>(result.Resource!);
        
        return Ok(supplyResource);
    }

    [HttpGet("category/{category}")]
    [SwaggerOperation(
        Summary = "Listar insumos por categoría",
        Description = "Obtiene una lista de insumos filtrados por categoría",
        Tags = new[] { "Supplies" }
    )]
    public async Task<IActionResult> GetByCategoryAsync(string category)
    {
        var supplies = await _supplyService.ListByCategoryAsync(category);
        var resources = _mapper.Map<IEnumerable<Supply>, IEnumerable<SupplyResource>>(supplies);
        
        return Ok(resources);
    }

    [HttpGet("expiration")]
    [SwaggerOperation(
        Summary = "Listar insumos por rango de fecha de vencimiento",
        Description = "Obtiene una lista de insumos filtrados por rango de fecha de vencimiento",
        Tags = new[] { "Supplies" }
    )]
    public async Task<IActionResult> GetByExpirationDateRangeAsync(
        [FromQuery] DateTime startDate, 
        [FromQuery] DateTime endDate)
    {
        var supplies = await _supplyService.ListByExpirationDateRangeAsync(startDate, endDate);
        var resources = _mapper.Map<IEnumerable<Supply>, IEnumerable<SupplyResource>>(supplies);
        
        return Ok(resources);
    }

    [HttpPost]
    [SwaggerOperation(
        Summary = "Crear un nuevo insumo",
        Description = "Crea un nuevo insumo con la información proporcionada",
        Tags = new[] { "Supplies" }
    )]
    public async Task<IActionResult> PostAsync([FromBody] SaveSupplyResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
            
        var supply = _mapper.Map<SaveSupplyResource, Supply>(resource);
        var result = await _supplyService.SaveAsync(supply);
        
        if (!result.Success)
            return BadRequest(result.Message);
            
        var supplyResource = _mapper.Map<Supply, SupplyResource>(result.Resource!);
        
        return Created($"/api/supplies/{supplyResource.Id}", supplyResource);
    }

    [HttpPut("{id}")]
    [SwaggerOperation(
        Summary = "Actualizar un insumo existente",
        Description = "Actualiza un insumo existente con la información proporcionada",
        Tags = new[] { "Supplies" }
    )]
    public async Task<IActionResult> PutAsync(int id, [FromBody] SaveSupplyResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
            
        var supply = _mapper.Map<SaveSupplyResource, Supply>(resource);
        var result = await _supplyService.UpdateAsync(id, supply);
        
        if (!result.Success)
            return BadRequest(result.Message);
            
        var supplyResource = _mapper.Map<Supply, SupplyResource>(result.Resource!);
        
        return Ok(supplyResource);
    }

    [HttpDelete("{id}")]
    [SwaggerOperation(
        Summary = "Eliminar un insumo",
        Description = "Elimina un insumo existente por su ID",
        Tags = new[] { "Supplies" }
    )]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var result = await _supplyService.DeleteAsync(id);
        
        if (!result.Success)
            return BadRequest(result.Message);
            
        var supplyResource = _mapper.Map<Supply, SupplyResource>(result.Resource!);
        
        return Ok(supplyResource);
    }
}
