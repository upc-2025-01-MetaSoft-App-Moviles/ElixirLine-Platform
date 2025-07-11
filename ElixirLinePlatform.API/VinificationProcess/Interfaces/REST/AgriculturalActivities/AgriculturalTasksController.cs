using ElixirLinePlatform.API.VinificationProcess.Domain.Model.AgriculturalActivities;
using ElixirLinePlatform.API.VinificationProcess.Domain.Services.AgriculturalActivities;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ElixirLinePlatform.API.VinificationProcess.Interfaces.REST.Resources;

namespace ElixirLinePlatform.API.VinificationProcess.Interfaces.REST.AgriculturalActivities
{
    [ApiController]
    [Route("api/tasks")]
    public class AgriculturalTasksController : ControllerBase
    {
        private readonly IAgriculturalTaskService _taskService;

        public AgriculturalTasksController(IAgriculturalTaskService taskService)
        {
            _taskService = taskService;
        }

        [HttpGet]
        [SwaggerOperation(Summary = "List all agricultural tasks")]
        public async Task<ActionResult<IEnumerable<AgriculturalTask>>> GetAll()
        {
            var tasks = await _taskService.ListAsync();
            return Ok(tasks);
        }

        [HttpGet("{id}")]
        [SwaggerOperation(Summary = "Get a specific task by ID")]
        public async Task<ActionResult<AgriculturalTask>> GetById(Guid id)
        {
            var task = await _taskService.GetByIdAsync(id);
            if (task == null) return NotFound();
            return Ok(task);
        }

        [HttpPost]
        public async Task<ActionResult<AgriculturalTask>> Create([FromBody] CreateAgriculturalTaskRequest request)
        {
            var task = new AgriculturalTask(
                Guid.NewGuid(),
                request.Title,
                request.Description,
                request.ParcelId,
                request.AssignedTo,
                request.ScheduledDate,
                request.Stage
            );
            var created = await _taskService.CreateAsync(task);
            return CreatedAtAction(nameof(GetById), new { id = created.TaskId }, created);
        }

        [HttpPut("{id}")]
        [SwaggerOperation(Summary = "Update an existing task")]
        public async Task<ActionResult<AgriculturalTask>> Update(Guid id, [FromBody] AgriculturalTask task)
        {
            var updated = await _taskService.UpdateAsync(id, task);
            if (updated == null) return NotFound();
            return Ok(updated);
        }

        [HttpDelete("{id}")]
        [SwaggerOperation(Summary = "Delete a task")]
        public async Task<ActionResult> Delete(Guid id)
        {
            var deleted = await _taskService.DeleteAsync(id);
            if (deleted == null) return NotFound();
            return NoContent();
        }
    }
}
