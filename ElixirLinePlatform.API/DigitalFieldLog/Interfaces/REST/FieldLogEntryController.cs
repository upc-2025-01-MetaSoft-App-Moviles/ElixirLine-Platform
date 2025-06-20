using System.Net.Mime;
using ElixirLinePlatform.API.DigitalFieldLog.Domain.Model.Queries;
using ElixirLinePlatform.API.DigitalFieldLog.Domain.Services;
using ElixirLinePlatform.API.DigitalFieldLog.Interfaces.REST.Resources;
using ElixirLinePlatform.API.DigitalFieldLog.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace ElixirLinePlatform.API.DigitalFieldLog.Interfaces.REST;

[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
[SwaggerTag("Available Field Log Entry Endpoints")]
public class FieldLogEntryController(
    IFieldLogEntryCommandService commandService,
    IFieldLogEntryQueryService queryService
) : ControllerBase
{
    // GET ALL ENTRIES -----------------------------------------------------
    [HttpGet]
    [SwaggerOperation(
        Summary = "Get all field log entries",
        Description = "Retrieve all field log entries from the system",
        OperationId = "GetAllFieldLogEntries"
    )]
    [SwaggerResponse(StatusCodes.Status200OK, "Entries retrieved successfully", typeof(IEnumerable<FieldLogEntryResource>))]
    public async Task<IActionResult> GetAll()
    {
        var query = new GetAllFieldLogEntriesQuery();
        var entries = await queryService.Handle(query);
        var resources = entries.Select(FieldLogEntryResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(resources);
    }

    // POST ENTRY -----------------------------------------------------
    [HttpPost]
    [SwaggerOperation(
        Summary = "Create a new field log entry",
        Description = "Registers a new field log entry with observations or incidents",
        OperationId = "CreateFieldLogEntry"
    )]
    [SwaggerResponse(StatusCodes.Status201Created, "Entry created successfully", typeof(FieldLogEntryResource))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid input")]
    public async Task<IActionResult> Create([FromBody] CreateFieldLogEntryResource resource)
    {
        var command = CreateFieldLogEntryCommandFromResourceAssembler.ToCommandFromResource(resource);
        var entry = await commandService.Handle(command);

        if (entry is null) return BadRequest();

        var result = FieldLogEntryResourceFromEntityAssembler.ToResourceFromEntity(entry);

        return CreatedAtAction(nameof(GetAll), new { entryId = entry.EntryId }, result);
    }
}