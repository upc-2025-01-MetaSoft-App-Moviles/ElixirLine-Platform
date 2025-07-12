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
[Route("api/v1/wine-batch/{batchId:guid}/bottling")]
[Produces("application/json")]
[SwaggerTag(description: "Endpoints for managing the Bottling Stage of a Wine Batch")]
public class BottlingStageController(IWineBatchQueryService wineBatchQueryService, IWineBatchCommandService wineBatchCommandService): ControllerBase
{
    
    //=========== GET BOTTLING STAGE BY WINE BATCH ID
    [HttpGet]
    [SwaggerOperation(
        Summary = "Get Bottling Stage by Wine Batch ID",
        Description = "Retrieves the Bottling Stage associated with a specific Wine Batch.",
        OperationId = "GetBottlingStageByWineBatchId"
        )]
    [SwaggerResponse(StatusCodes.Status200OK, "The bottling stage was successfully retrieved", typeof(BottlingStageResource))]
    [SwaggerResponse(StatusCodes.Status404NotFound, "The wine batch or bottling stage was not found")]
    public async Task<IActionResult> GetBottlingStageByWineBatchId([FromRoute] Guid batchId)
    {
        var query = new GetBottlingStageByWineBatchIdQuery(batchId);
        
        var bottlingStage = await wineBatchQueryService.Handle(query);
        
        if (bottlingStage == null)
            return NotFound("No se encontró la etapa de embotellado para el lote de vino especificado.");
        
        // Mapear bottlingStage a BottlingStageResource
        var bottlingStageResource = BottlingStageResourceFromEntityAssembler.ToResourceFromEntity(bottlingStage);
        
        return Ok(bottlingStageResource);
    }
    
    // =========== POST BOTTLING
    [HttpPost]
    [SwaggerOperation(
        Summary = "Create a new Bottling Stage by Wine Batch",
        Description = "Create a new Bottling Stage by Wine Batch",
        OperationId = "CreateBottlingStageByWineBatch"
        )]
    [SwaggerResponse(StatusCodes.Status201Created, "The Bottling Stage was successfully created", typeof(BottlingStageResource))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "The Bottling Stage was not created")]
    public async Task<IActionResult> AddBottlingStageByBatch([FromBody] AddBottlingStageResource resource, [FromRoute] Guid batchId)
    {
        var command = AddBottlingStageByWineBatchCommandFromResourceAssembler.ToCommandFromResource(resource);

        var bottlingStage = await wineBatchCommandService.Handle(command, batchId);
        
        if (bottlingStage == null)
            return BadRequest("No se pudo crear la etapa de embotellado para el lote de vino especificado.");
        
        // Mapear bottlingStage a BottlingStageResource
        var bottlingStageResource = BottlingStageResourceFromEntityAssembler.ToResourceFromEntity(bottlingStage);
        
        return CreatedAtAction(nameof(GetBottlingStageByWineBatchId), new { batchId = bottlingStage.BatchId }, bottlingStageResource);
    }
    
    // =========== PUT BOTTLING
    [HttpPut]
    [SwaggerOperation(
        Summary = "Update an existing Bottling Stage by Wine Batch",
        Description = "Update an existing Bottling Stage by Wine Batch",
        OperationId = "UpdateBottlingStageByWineBatch"
        )]
    [SwaggerResponse(StatusCodes.Status200OK, "The Bottling Stage was successfully updated", typeof(BottlingStageResource))]
    [SwaggerResponse(StatusCodes.Status404NotFound, "The Bottling Stage was not found")]
    public async Task<IActionResult> UpdateBottlingStageByWineBatch([FromBody] UpdateBottlingStageResource resource, [FromRoute] Guid batchId)
    {

        
        var command = UpdateBottlingStageByWineBatchCommandFromResourceAssembler.ToCommandFromResource(resource);

        var bottlingStage = await wineBatchCommandService.Handle(command, batchId);
        
        if (bottlingStage == null)
            return NotFound("No se encontró la etapa de embotellado para el lote de vino especificado.");
        
        // Mapear bottlingStage a BottlingStageResource
        var bottlingStageResource = BottlingStageResourceFromEntityAssembler.ToResourceFromEntity(bottlingStage);
        
        return Ok(bottlingStageResource);
    }
    
    
}