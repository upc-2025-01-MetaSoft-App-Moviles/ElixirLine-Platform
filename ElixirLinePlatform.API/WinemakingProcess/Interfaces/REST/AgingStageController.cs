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
[Route("api/v1/wine-batch/{batchId:guid}/aging")]
[Produces("application/json")]
[SwaggerTag(description: "Endpoints for managing the Aging Stage of a Wine Batch")]
public class AgingStageController(IWineBatchQueryService wineBatchQueryService, IWineBatchCommandService wineBatchCommandService): ControllerBase
{
    
    //=========== GET AGING STAGE BY WINE BATCH ID
    [HttpGet]
    [SwaggerOperation(
        Summary = "Get Aging Stage by Wine Batch ID",
        Description = "Retrieves the Aging Stage associated with a specific Wine Batch.",
        OperationId = "GetAgingStageByWineBatchId"
        )]
    [SwaggerResponse(StatusCodes.Status200OK, "The aging stage was successfully retrieved", typeof(AgingStageResource))]
    [SwaggerResponse(StatusCodes.Status404NotFound, "The wine batch or aging stage was not found")]
    public async Task<IActionResult> GetAgingStageByWineBatchId([FromRoute] Guid batchId)
    {
        var query = new GetAgingStageByWineBatchIdQuery(batchId);
        
        var agingStage = await wineBatchQueryService.Handle(query);
        
        if (agingStage == null)
            return NotFound("No se encontró la etapa de envejecimiento para el lote de vino especificado.");
        
        // Mapear agingStage a AgingStageResource
        var agingStageResource = AgingStageResourceFromEntityAssembler.ToResourceFromEntity(agingStage);
        
        return Ok(agingStageResource);
    }
    
    // =========== POST AGING
    [HttpPost]
    [SwaggerOperation(
        Summary = "Create a new Aging Stage by Wine Batch",
        Description = "Create a new Aging Stage by Wine Batch",
        OperationId = "CreateAgingStageByWineBatch"
        )]
    [SwaggerResponse(StatusCodes.Status201Created, "The Aging Stage was successfully created", typeof(AgingStageResource))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "The Aging Stage was not created")]
    public async Task<IActionResult> AddAgingStageByBatch([FromBody] AddAgingStageResource resource, [FromRoute] Guid batchId)
    {
        var command = AddAgingStageByWineBatchCommandFromResourceAssembler.ToCommandFromResource(resource);

        var agingStage = await wineBatchCommandService.Handle(command, batchId);
        
        if (agingStage == null)
            return BadRequest("No se pudo crear la etapa de envejecimiento para el lote de vino especificado.");
        
        // Mapear agingStage a AgingStageResource
        var agingStageResource = AgingStageResourceFromEntityAssembler.ToResourceFromEntity(agingStage);
        
        return CreatedAtAction(nameof(GetAgingStageByWineBatchId), new { batchId = agingStage.BatchId }, agingStageResource);
    }
    
    
}
