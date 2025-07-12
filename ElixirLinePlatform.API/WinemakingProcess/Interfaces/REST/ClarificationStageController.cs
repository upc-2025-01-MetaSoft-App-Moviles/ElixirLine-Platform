using ElixirLinePlatform.API.WinemakingProcess.Domain.Model.Queries;
using ElixirLinePlatform.API.WinemakingProcess.Domain.Services;
using ElixirLinePlatform.API.WinemakingProcess.Interfaces.REST.Resources.AddCommandStagesResources;
using ElixirLinePlatform.API.WinemakingProcess.Interfaces.REST.Resources.StagesResources;
using ElixirLinePlatform.API.WinemakingProcess.Interfaces.REST.Resources.UpdateCommandStagesResource;
using ElixirLinePlatform.API.WinemakingProcess.Interfaces.REST.Transform.CommandAssembler;
using ElixirLinePlatform.API.WinemakingProcess.Interfaces.REST.Transform.EntitiesAssembler;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace ElixirLinePlatform.API.WinemakingProcess.Interfaces.REST;


[ApiController]
[Route("api/v1/wine-batch/{batchId:guid}/clarification")]
[Produces("application/json")]
[SwaggerTag( "Endpoints for managing the Clarification Stage of a Wine Batch")]
public class ClarificationStageController(IWineBatchQueryService wineBatchQueryService, IWineBatchCommandService wineBatchCommandService): ControllerBase
{
    //=========== GET CLARIFICATION STAGE BY WINE BATCH ID
  
    [HttpGet]
    [SwaggerOperation(
        Summary = "Get Clarification Stage by Wine Batch ID",
        Description = "Retrieves the Clarification Stage associated with a specific Wine Batch.",
        OperationId = "GetClarificationStageByWineBatchId"
        )]
    [SwaggerResponse(StatusCodes.Status200OK, "The clarification stage was successfully retrieved", typeof(ClarificationStageResource))]
    [SwaggerResponse(StatusCodes.Status404NotFound, "The wine batch or clarification stage was not found")]
    public async Task<IActionResult> GetClarificationStageByWineBatchId([FromRoute] Guid batchId)
    {
        var query = new GetClarificationStageByWineBatchIdQuery(batchId);
        
        var clarificationStage = await wineBatchQueryService.Handle(query);
        
        if (clarificationStage == null)
            return NotFound("No se encontró la etapa de clarificación para el lote de vino especificado.");
        
        // Mapear clarificationStage a ClarificationStageResource
        var clarificationStageResource = ClarificationStageResourceFromEntityAssembler.ToResourceFromEntity(clarificationStage);
        
        return Ok(clarificationStageResource);
    }
    
    // =========== POST CLARIFICATION
    [HttpPost]
    [SwaggerOperation(
        Summary = "Create a new Clarification by Wine Batch",
        Description = "Create a new Clarification by Wine Batch",
        OperationId = "CreateClarificationByWineBatch"
        )]
    [SwaggerResponse(StatusCodes.Status201Created, "The Clarification was successfully created", typeof(ClarificationStageResource))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "The Clarification was not created")]
    public async Task<IActionResult> AddClarificationStageByBatch([FromBody] AddClarificationStageResource resource, [FromRoute] Guid batchId)
    {
        var command = AddClarificationStageByWineBatchCommandFromResourceAssembler.ToCommandFromResource(resource);

        var clarificationStage = await wineBatchCommandService.Handle(command, batchId);

        if (clarificationStage is null)
            return BadRequest("No se pudo agregar la etapa de clarificación.");        
        
        
        
        var clarificationStageResource = ClarificationStageResourceFromEntityAssembler.ToResourceFromEntity(clarificationStage);
        
        
        return CreatedAtAction(nameof(GetClarificationStageByWineBatchId), new { batchId }, clarificationStageResource);
    }
    
    // =========== PUT CLARIFICATION
    [HttpPut]
    [SwaggerOperation(
        Summary = "Update an existing Clarification by Wine Batch",
        Description = "Update an existing Clarification by Wine Batch",
        OperationId = "UpdateClarificationByWineBatch"
        )]
    [SwaggerResponse(StatusCodes.Status200OK, "The Clarification was successfully updated", typeof(ClarificationStageResource))]
    [SwaggerResponse(StatusCodes.Status404NotFound, "The Clarification or Wine Batch was not found")]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "The Clarification was not updated")]
    public async Task<IActionResult> UpdateClarificationStageByBatch([FromBody] UpdateClarificationStageResource resource, [FromRoute] Guid batchId)
    {
        
        var command = UpdateClarificationByWineBatchCommandFromResourceAssembler.ToCommandFromResource(resource);

        var clarificationStage = await wineBatchCommandService.Handle(command, batchId);

        if (clarificationStage is null)
            return BadRequest("No se pudo actualizar la etapa de clarificación.");        
        
        var clarificationStageResource = ClarificationStageResourceFromEntityAssembler.ToResourceFromEntity(clarificationStage);
        
        return Ok(clarificationStageResource);
    }
    
}