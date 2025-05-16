using ElixirLinePlatform.API.Modules.FieldWorkers.DTOs;
using ElixirLinePlatform.API.Modules.FieldWorkers.Services;
using Microsoft.AspNetCore.Mvc;

namespace ElixirLinePlatform.API.Modules.FieldWorkers.Controllers;

[ApiController]
[Route("fieldworkers")]
public class FieldWorkersController : ControllerBase
{
    private readonly FieldWorkerService _service;

    public FieldWorkersController(FieldWorkerService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var workers = await _service.GetAllAsync();
        return Ok(workers);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var worker = await _service.GetByIdAsync(id);
        if (worker == null) return NotFound(new { message = "Trabajador no encontrado." });
        return Ok(worker);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateFieldWorkerDTO dto)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        var created = await _service.CreateAsync(dto);
        return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdateFieldWorkerDTO dto)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        var updated = await _service.UpdateAsync(id, dto);
        if (!updated) return NotFound(new { message = "Trabajador no encontrado." });

        return Ok(new { message = "Actualizado correctamente." });
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var deleted = await _service.DeleteAsync(id);
        if (!deleted) return NotFound(new { message = "Trabajador no encontrado." });

        return Ok(new { message = "Eliminado correctamente." });
    }
}
