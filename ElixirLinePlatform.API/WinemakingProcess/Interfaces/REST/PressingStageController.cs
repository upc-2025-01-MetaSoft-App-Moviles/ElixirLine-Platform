using ElixirLinePlatform.API.WinemakingProcess.Domain.Model.Queries;
using ElixirLinePlatform.API.WinemakingProcess.Domain.Services;
using ElixirLinePlatform.API.WinemakingProcess.Interfaces.REST.Resources;
using ElixirLinePlatform.API.WinemakingProcess.Interfaces.REST.Resources.AddCommandStagesResources;
using ElixirLinePlatform.API.WinemakingProcess.Interfaces.REST.Resources.StagesResources;
using ElixirLinePlatform.API.WinemakingProcess.Interfaces.REST.Resources.UpdateCommandStagesResource;
using ElixirLinePlatform.API.WinemakingProcess.Interfaces.REST.Transform;
using ElixirLinePlatform.API.WinemakingProcess.Interfaces.REST.Transform.CommandAssembler;
using ElixirLinePlatform.API.WinemakingProcess.Interfaces.REST.Transform.EntitiesAssembler;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace ElixirLinePlatform.API.WinemakingProcess.Interfaces.REST;
[ApiController]
[Route("api/v1/wine-batch/{batchId:guid}/pressing")]
[Produces("application/json")]
[SwaggerTag("Endpoints for managing the Pressing Stage of a Wine Batch")]
public class PressingStageController(IWineBatchQueryService wineBatchQueryService, IWineBatchCommandService wineBatchCommandService) : ControllerBase
{
    
    
    // =========== GET PRESSING STAGE BY WINE BATCH ID
    [HttpGet]
    [SwaggerOperation(
        Summary = "Get Pressing Stage by Wine Batch ID",
        Description = "Retrieves the Pressing Stage associated with a specific Wine Batch.",
        OperationId = "GetPressingStageByWineBatchId"
        )]
    [SwaggerResponse(StatusCodes.Status200OK, "The pressing stage was successfully retrieved", typeof(PressingStageResource))]
    [SwaggerResponse(StatusCodes.Status404NotFound, "The wine batch or pressing stage was not found")]
    public async Task<IActionResult> GetPressingStageByWineBatchId([FromRoute] Guid batchId)
    {
        var query = new GetPressingStageByWineBatchIdQuery(batchId);
        
        var pressingStage = await wineBatchQueryService.Handle(query);
        
        if (pressingStage == null)
            return NotFound("No se encontró la etapa de prensado para el lote de vino especificado.");
        
        // Mapear pressingStage a PressingStageResource
        var pressingStageResource = PressingStageResourceFromEntityAssembler.ToResourceFromEntity(pressingStage);

        return Ok(pressingStage);
    }
    
    
    // =========== POST PRESSING
    [HttpPost]
    [SwaggerOperation(
        Summary = "Create a new Pressing by Wine Batch",
        Description = "Create a new Pressing by Wine Batch",
        OperationId = "CreatePressingByWineBatch"
        )]
    [SwaggerResponse(StatusCodes.Status201Created, "The Pressing was successfully created", typeof(PressingStageResource))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "The Pressing was not created")]
    public async Task<IActionResult> AddPressingStageByBatch([FromBody] AddPressingStageResource resource, [FromRoute] Guid batchId)
    {
        var command = AddPressingStageByWineBatchCommandFromResourceAssembler.ToCommandFromResource(resource);

        var pressingStage = await wineBatchCommandService.Handle(command, batchId);

        if (pressingStage is null)
            return BadRequest("No se pudo agregar la etapa de prensado.");        
        
        var pressingStageResource = PressingStageResourceFromEntityAssembler.ToResourceFromEntity(pressingStage);
        
        return CreatedAtAction(nameof(GetPressingStageByWineBatchId), new { batchId }, pressingStageResource);
    }
    
    // =========== PUT PRESSING
    [HttpPut]
    [SwaggerOperation(
        Summary = "Update an existing Pressing by Wine Batch",
        Description = "Update an existing Pressing by Wine Batch",
        OperationId = "UpdatePressingByWineBatch"
        )]
    [SwaggerResponse(StatusCodes.Status200OK, "The Pressing was successfully updated", typeof(PressingStageResource))]
    [SwaggerResponse(StatusCodes.Status404NotFound, "The Pressing or Wine Batch was not found")]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "The Pressing was not updated")]

    public async Task<IActionResult> UpdatePressingStageByBatch([FromBody] UpdatePressingStageResource resource, [FromRoute] Guid batchId)
    {
        
        
        var command = UpdatePressingStageByWineBatchCommandFromResourceAssembler.ToCommandFromResource(resource);

        var updatedPressingStage = await wineBatchCommandService.Handle(command, batchId);

        if (updatedPressingStage is null)
            return NotFound("No se encontró la etapa de prensado o el lote de vino especificado.");

        var updatedPressingStageResource = PressingStageResourceFromEntityAssembler.ToResourceFromEntity(updatedPressingStage);
        
        return Ok(updatedPressingStageResource);
    }
    
    
    
    
}