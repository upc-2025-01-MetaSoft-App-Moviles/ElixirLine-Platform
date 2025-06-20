using ElixirLinePlatform.API.VinificationProcess.Domain.Model.AgriculturalActivities;
using ElixirLinePlatform.API.VinificationProcess.Domain.Services.AgriculturalActivities;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ElixirLinePlatform.API.VinificationProcess.Interfaces.REST.AgriculturalActivities
{
    [ApiController]
    [Route("api/tasks/{taskId}/reports")]
    public class TaskExecutionReportsController : ControllerBase
    {
        private readonly ITaskExecutionReportService _reportService;

        public TaskExecutionReportsController(ITaskExecutionReportService reportService)
        {
            _reportService = reportService;
        }

        [HttpGet]
        [SwaggerOperation(Summary = "List reports for a specific agricultural task")]
        public async Task<ActionResult<IEnumerable<TaskExecutionReport>>> GetAll(Guid taskId)
        {
            var reports = await _reportService.ListByTaskIdAsync(taskId);
            return Ok(reports);
        }

        [HttpGet("{id}")]
        [SwaggerOperation(Summary = "Get a specific execution report by ID")]
        public async Task<ActionResult<TaskExecutionReport>> GetById(Guid taskId, Guid id)
        {
            var report = await _reportService.GetByIdAsync(id);
            if (report == null || report.TaskId != taskId) return NotFound();
            return Ok(report);
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Create a new task execution report")]
        public async Task<ActionResult<TaskExecutionReport>> Create(Guid taskId, [FromBody] TaskExecutionReport report)
        {
            report.SetTaskId(taskId);
            var created = await _reportService.CreateAsync(report);
            return CreatedAtAction(nameof(GetById), new { taskId, id = created.ReportId }, created);
        }

        [HttpPut("{id}")]
        [SwaggerOperation(Summary = "Update an existing report")]
        public async Task<ActionResult<TaskExecutionReport>> Update(Guid taskId, Guid id, [FromBody] TaskExecutionReport report)
        {
            var updated = await _reportService.UpdateAsync(id, report);
            if (updated == null || updated.TaskId != taskId) return NotFound();
            return Ok(updated);
        }

        [HttpDelete("{id}")]
        [SwaggerOperation(Summary = "Delete a report")]
        public async Task<ActionResult> Delete(Guid taskId, Guid id)
        {
            var deleted = await _reportService.DeleteAsync(id);
            if (deleted == null || deleted.TaskId != taskId) return NotFound();
            return NoContent();
        }
    }
}
