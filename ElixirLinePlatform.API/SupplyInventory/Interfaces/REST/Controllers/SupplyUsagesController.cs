using AutoMapper;
using ElixirLinePlatform.API.SupplyInventory.Domain.Model.Entities;
using ElixirLinePlatform.API.SupplyInventory.Domain.Services;
using ElixirLinePlatform.API.SupplyInventory.Interfaces.REST.Resources;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace ElixirLinePlatform.API.SupplyInventory.Interfaces.REST.Controllers;

[ApiController]
[Route("api/supply-usages")]
[Produces("application/json")]
public class SupplyUsagesController : ControllerBase
{
    private readonly ISupplyUsageService _supplyUsageService;
    private readonly IMapper _mapper;

    public SupplyUsagesController(ISupplyUsageService supplyUsageService, IMapper mapper)
    {
        _supplyUsageService = supplyUsageService;
        _mapper = mapper;
    }

    [HttpGet]
    [SwaggerOperation(
        Summary = "Listar todos los registros de uso de insumos",
        Description = "Obtiene una lista de todos los registros de uso de insumos",
        Tags = new[] { "SupplyUsages" }
    )]
    public async Task<IActionResult> GetAllAsync()
    {
        var supplyUsages = await _supplyUsageService.ListAsync();
        var resources = _mapper.Map<IEnumerable<SupplyUsage>, IEnumerable<SupplyUsageResource>>(supplyUsages);
        
        return Ok(resources);
    }

    [HttpGet("{id}")]
    [SwaggerOperation(
        Summary = "Obtener un registro de uso por ID",
        Description = "Obtiene un registro de uso específico por su ID",
        Tags = new[] { "SupplyUsages" }
    )]
    public async Task<IActionResult> GetByIdAsync(int id)
    {
        var result = await _supplyUsageService.FindByIdAsync(id);
        
        if (!result.Success)
            return NotFound(result.Message);
            
        var supplyUsageResource = _mapper.Map<SupplyUsage, SupplyUsageResource>(result.Resource!);
        
        return Ok(supplyUsageResource);
    }

    [HttpGet("supply/{supplyId}")]
    [SwaggerOperation(
        Summary = "Listar registros de uso por insumo",
        Description = "Obtiene una lista de registros de uso filtrados por ID de insumo",
        Tags = new[] { "SupplyUsages" }
    )]
    public async Task<IActionResult> GetBySupplyIdAsync(int supplyId)
    {
        var supplyUsages = await _supplyUsageService.ListBySupplyIdAsync(supplyId);
        var resources = _mapper.Map<IEnumerable<SupplyUsage>, IEnumerable<SupplyUsageResource>>(supplyUsages);
        
        return Ok(resources);
    }

    [HttpGet("date-range")]
    [SwaggerOperation(
        Summary = "Listar registros de uso por rango de fechas",
        Description = "Obtiene una lista de registros de uso filtrados por rango de fechas",
        Tags = new[] { "SupplyUsages" }
    )]
    public async Task<IActionResult> GetByDateRangeAsync(
        [FromQuery] DateTime startDate, 
        [FromQuery] DateTime endDate)
    {
        var supplyUsages = await _supplyUsageService.ListByDateRangeAsync(startDate, endDate);
        var resources = _mapper.Map<IEnumerable<SupplyUsage>, IEnumerable<SupplyUsageResource>>(supplyUsages);
        
        return Ok(resources);
    }

    [HttpPost]
    [SwaggerOperation(
        Summary = "Registrar uso de insumo",
        Description = "Registra el uso de un insumo con la información proporcionada",
        Tags = new[] { "SupplyUsages" }
    )]
    public async Task<IActionResult> PostAsync([FromBody] SaveSupplyUsageResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
            
        var supplyUsage = _mapper.Map<SaveSupplyUsageResource, SupplyUsage>(resource);
        var result = await _supplyUsageService.SaveAsync(supplyUsage);
        
        if (!result.Success)
            return BadRequest(result.Message);
            
        var supplyUsageResource = _mapper.Map<SupplyUsage, SupplyUsageResource>(result.Resource!);
        
        return Created($"/api/supply-usages/{supplyUsageResource.Id}", supplyUsageResource);
    }

    [HttpPut("{id}")]
    [SwaggerOperation(
        Summary = "Actualizar un registro de uso",
        Description = "Actualiza un registro de uso existente con la información proporcionada",
        Tags = new[] { "SupplyUsages" }
    )]
    public async Task<IActionResult> PutAsync(int id, [FromBody] SaveSupplyUsageResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
            
        var supplyUsage = _mapper.Map<SaveSupplyUsageResource, SupplyUsage>(resource);
        var result = await _supplyUsageService.UpdateAsync(id, supplyUsage);
        
        if (!result.Success)
            return BadRequest(result.Message);
            
        var supplyUsageResource = _mapper.Map<SupplyUsage, SupplyUsageResource>(result.Resource!);
        
        return Ok(supplyUsageResource);
    }

    [HttpDelete("{id}")]
    [SwaggerOperation(
        Summary = "Eliminar un registro de uso",
        Description = "Elimina un registro de uso existente por su ID",
        Tags = new[] { "SupplyUsages" }
    )]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var result = await _supplyUsageService.DeleteAsync(id);
        
        if (!result.Success)
            return BadRequest(result.Message);
            
        var supplyUsageResource = _mapper.Map<SupplyUsage, SupplyUsageResource>(result.Resource!);
        
        return Ok(supplyUsageResource);
    }
}
