using ElixirLinePlatform.API.WinemakingProcess.Domain.Model.Queries;
using ElixirLinePlatform.API.WinemakingProcess.Domain.Services;
using ElixirLinePlatform.API.WinemakingProcess.Interfaces.REST.Resources;
using ElixirLinePlatform.API.WinemakingProcess.Interfaces.REST.Resources.CommandStagesResources;
using ElixirLinePlatform.API.WinemakingProcess.Interfaces.REST.Resources.StagesResources;
using ElixirLinePlatform.API.WinemakingProcess.Interfaces.REST.Transform;
using ElixirLinePlatform.API.WinemakingProcess.Interfaces.REST.Transform.CommandAssembler;
using ElixirLinePlatform.API.WinemakingProcess.Interfaces.REST.Transform.EntitiesAssembler;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace ElixirLinePlatform.API.WinemakingProcess.Interfaces.REST;
[ApiController]
[Route("api/v1/wine-batches/{batchId:guid}/pressing")]
[Produces("application/json")]
[SwaggerTag("Endpoints for managing the Pressing Stage of a Wine Batch")]
public class PressingStageController(IWineBatchQueryService wineBatchQueryService, IWineBatchCommandService wineBatchCommandService) : ControllerBase
{
    
    [HttpGet]
    [SwaggerOperation(
        Summary = "Get Pressing Stage by Wine Batch ID",
        Description = "Retrieves the Pressing Stage associated with a specific Wine Batch.",
        OperationId = "GetPressingStageByWineBatchId")]
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
    
    [HttpPost]
    [SwaggerOperation(
        Summary = "Create a new Pressing by Wine Batch",
        Description = "Create a new Pressing by Wine Batch",
        OperationId = "CreatePressingByWineBatch")]
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
    
    
    
    
    
}