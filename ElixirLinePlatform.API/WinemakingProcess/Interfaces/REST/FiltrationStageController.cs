using ElixirLinePlatform.API.WinemakingProcess.Domain.Model.Queries;
using ElixirLinePlatform.API.WinemakingProcess.Domain.Services;
using ElixirLinePlatform.API.WinemakingProcess.Interfaces.REST.Resources.AddCommandStagesResources;
using ElixirLinePlatform.API.WinemakingProcess.Interfaces.REST.Resources.StagesResources;
using ElixirLinePlatform.API.WinemakingProcess.Interfaces.REST.Transform.CommandAssembler;
using ElixirLinePlatform.API.WinemakingProcess.Interfaces.REST.Transform.EntitiesAssembler;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace ElixirLinePlatform.API.WinemakingProcess.Interfaces.REST;


[ApiController]
[Route("api/v1/wine-batch/{batchId:guid}/filtration")]
[Produces("application/json")]
[SwaggerTag("Endpoints for managing the Filtration Stage of a Wine Batch")]
public class FiltrationStageController(IWineBatchQueryService wineBatchQueryService, IWineBatchCommandService wineBatchCommandService): ControllerBase
{
    
    //=========== GET FILTRATION STAGE BY WINE BATCH ID
    [HttpGet]
    [SwaggerOperation(
        Summary = "Get Filtration Stage by Wine Batch ID",
        Description = "Retrieves the Filtration Stage associated with a specific Wine Batch.",
        OperationId = "GetFiltrationStageByWineBatchId"
        )]
    [SwaggerResponse(StatusCodes.Status200OK, "The filtration stage was successfully retrieved", typeof(FiltrationStageResource))]
    [SwaggerResponse(StatusCodes.Status404NotFound, "The wine batch or filtration stage was not found")]
    public async Task<IActionResult> GetFiltrationStageByWineBatchId([FromRoute] Guid batchId)
    {
        var query = new GetFiltrationStageByWineBatchIdQuery(batchId);
        
        var filtrationStage = await wineBatchQueryService.Handle(query);
        
        if (filtrationStage == null)
            return NotFound("No se encontró la etapa de filtración para el lote de vino especificado.");
        
        // Mapear filtrationStage a FiltrationStageResource
        var filtrationStageResource = FiltrationStageResourceFromEntityAssembler.ToResourceFromEntity(filtrationStage);
        
        return Ok(filtrationStageResource);
    }
    
    
    // =========== POST FILTRATION
    [HttpPost]
    [SwaggerOperation(
        Summary = "Create a new Filtration Stage by Wine Batch",
        Description = "Create a new Filtration Stage by Wine Batch",
        OperationId = "CreateFiltrationStageByWineBatch"
        )]
    [SwaggerResponse(StatusCodes.Status201Created, "The Filtration Stage was successfully created", typeof(FiltrationStageResource))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "The Filtration Stage was not created")]
    public async Task<IActionResult> AddFiltrationStageByBatch([FromBody] AddFiltrationStageResource resource, [FromRoute] Guid batchId)
    {
        var command = AddFiltrationStageByWineBatchCommandFromResourceAssembler.ToCommandFromResource(resource);

        var filtrationStage = await wineBatchCommandService.Handle(command, batchId);
        
        if (filtrationStage == null)
            return BadRequest("No se pudo crear la etapa de filtración para el lote de vino especificado.");
        
        // Mapear filtrationStage a FiltrationStageResource
        var filtrationStageResource = FiltrationStageResourceFromEntityAssembler.ToResourceFromEntity(filtrationStage);
        
        return CreatedAtAction(nameof(GetFiltrationStageByWineBatchId), new { batchId = filtrationStage.BatchId }, filtrationStageResource);
    }
    
    
}