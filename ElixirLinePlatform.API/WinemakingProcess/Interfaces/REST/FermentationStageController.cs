using ElixirLinePlatform.API.WinemakingProcess.Domain.Model.Queries;
using ElixirLinePlatform.API.WinemakingProcess.Domain.Services;
using ElixirLinePlatform.API.WinemakingProcess.Interfaces.REST.Resources;
using ElixirLinePlatform.API.WinemakingProcess.Interfaces.REST.Resources.AddCommandStagesResources;
using ElixirLinePlatform.API.WinemakingProcess.Interfaces.REST.Resources.StagesResources;
using ElixirLinePlatform.API.WinemakingProcess.Interfaces.REST.Transform;
using ElixirLinePlatform.API.WinemakingProcess.Interfaces.REST.Transform.CommandAssembler;
using ElixirLinePlatform.API.WinemakingProcess.Interfaces.REST.Transform.EntitiesAssembler;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace ElixirLinePlatform.API.WinemakingProcess.Interfaces.REST;


[ApiController]
[Route("api/v1/wine-batch/{batchId:guid}/fermentation")]
[Produces("application/json")]
[SwaggerTag("Endpoints for managing the Clarification Stage of a Wine Batch")]
public class FermentationStageController(IWineBatchQueryService wineBatchQueryService, IWineBatchCommandService wineBatchCommandService): ControllerBase
{
  
    //=========== GET FERMENTATION STAGE BY WINE BATCH ID
    [HttpGet]
    [SwaggerOperation(
        Summary = "Get Fermentation Stage by Wine Batch ID",
        Description = "Retrieves the Fermentation Stage associated with a specific Wine Batch.",
        OperationId = "GetFermentationStageByWineBatchId"
        )]
    [SwaggerResponse(StatusCodes.Status200OK, "The fermentation stage was successfully retrieved", typeof(FermentationStageResource))]
    [SwaggerResponse(StatusCodes.Status404NotFound, "The wine batch or fermentation stage was not found")]
    public async Task<IActionResult> GetFermentationStageByWineBatchId([FromRoute] Guid batchId)
    {
        var query = new GetFermentationStageByWineBatchIdQuery(batchId);
        
        var fermentationStage = await wineBatchQueryService.Handle(query);
        
        if (fermentationStage == null)
            return NotFound("No se encontró la etapa de fermentación para el lote de vino especificado.");
        
        // Mapear fermentationStage a FermentationStageResource
        var fermentationStageResource = FermentationStageResourceFromEntityAssembler.ToResourceFromEntity(fermentationStage);
        
        return Ok(fermentationStageResource);
    }
    
    // =========== POST FERMENTATION
    [HttpPost]
    [SwaggerOperation(
        Summary = "Create a new Fermentation by Wine Batch",
        Description = "Create a new Fermentation by Wine Batch",
        OperationId = "CreateFermentationByWineBatch"
        )]
    [SwaggerResponse(StatusCodes.Status201Created, "The Fermentation was successfully created", typeof(FermentationStageResource))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "The Fermentation was not created")]
    public async Task<IActionResult> AddFermentationStageByBatch([FromBody] AddFermentationStageResource resource, [FromRoute] Guid batchId)
    {
        var command = AddFermentationStageByWineBatchCommandFromResourceAssembler.ToCommandFromResource(resource);

        var fermentationStage = await wineBatchCommandService.Handle(command, batchId);

        if (fermentationStage is null)
            return BadRequest("No se pudo agregar la etapa de fermentación.");        
       
        
        var fermentationStageResource = FermentationStageResourceFromEntityAssembler.ToResourceFromEntity(fermentationStage);
        
        
        return CreatedAtAction(nameof(GetFermentationStageByWineBatchId), new { batchId = batchId }, fermentationStageResource);
    }  
}