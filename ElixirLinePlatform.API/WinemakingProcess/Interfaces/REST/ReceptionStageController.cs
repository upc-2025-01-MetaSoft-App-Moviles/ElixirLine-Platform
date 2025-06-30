using System.Net.Mime;
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
[Route("api/v1/wine-batch/{batchId:guid}/reception")]
[Produces(MediaTypeNames.Application.Json)]
[SwaggerTag("Endpoints for managing the Reception Stage of a Wine Batch")]
public class ReceptionStageController(IWineBatchQueryService wineBatchQueryService, IWineBatchCommandService wineBatchCommandService): ControllerBase
{
    
 //=========== GET RECEPTION STAGE BY WINE BATCH ID
    [HttpGet]
    [SwaggerOperation(
        Summary = "Get Reception Stage by Wine Batch ID",
        Description = "Retrieves the Reception Stage associated with a specific Wine Batch.",
        OperationId = "GetReceptionStageByWineBatchId"
        )]
    [SwaggerResponse(StatusCodes.Status200OK, "The reception stage was successfully retrieved", typeof(ReceptionStageResource))]
    [SwaggerResponse(StatusCodes.Status404NotFound, "The wine batch or reception stage was not found")]
    public async Task<IActionResult> GetReceptionStageByWineBatchId([FromRoute] Guid batchId)
    {
        var query = new GetReceptionStageByWineBatchIdQuery(batchId);
        
        var receptionStage = await wineBatchQueryService.Handle(query);
        
        if (receptionStage == null)
            return NotFound("No se encontró la etapa de recepción para el lote de vino especificado.");
        
        // Mapear receptionStage a ReceptionStageResource
        var receptionStageResource = ReceptionStageResourceFromEntityAssembler.ToResourceFromEntity(receptionStage);
        
        return Ok(receptionStageResource);
    }


    // =========== POST RECEPTION
    [HttpPost]
    [SwaggerOperation(
        Summary = "Create a new Reception by Wine Batch",
        Description = "Create a new Reception by Wine Batch",
        OperationId = "CreateReceptionByWineBatch"
        )]
    [SwaggerResponse(StatusCodes.Status201Created, "The Reception was successfully created", typeof(ReceptionStageResource))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "The Reception was not created")]
    public async Task<IActionResult> AddReceptionStageByBatch([FromBody] AddReceptionStageResource resource, [FromRoute] Guid batchId)
    {
        var command = AddReceptionStageByWineBatchCommandFromResourceAssembler.ToCommandFromResource(resource);

        var receptionStage = await wineBatchCommandService.Handle(command, batchId);

        if (receptionStage is null)
            return BadRequest("No se pudo agregar la etapa de recepción.");        
       
        
        var receptionStageResource = ReceptionStageResourceFromEntityAssembler.ToResourceFromEntity(receptionStage);
        
        
        return CreatedAtAction(nameof(GetReceptionStageByWineBatchId), new { batchId = batchId }, receptionStageResource);
    }
    
    // =========== PUT RECEPTION
    [HttpPut]
    [SwaggerOperation(
        Summary = "Update Reception Stage by Wine Batch",
        Description = "Update the Reception Stage of a specific Wine Batch.",
        OperationId = "UpdateReceptionStageByWineBatch"
        )]
    [SwaggerResponse(StatusCodes.Status200OK, "The Reception Stage was successfully updated", typeof(ReceptionStageResource))]
    [SwaggerResponse(StatusCodes.Status404NotFound, "The Wine Batch or Reception Stage was not found")]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "The Reception Stage was not updated")]
    public async Task<IActionResult> UpdateReceptionStageByBatch([FromBody] UpdateReceptionStageResource resource, [FromRoute] Guid batchId)
    {
        var command = UpdateReceptionStageByWineBatchCommandFromResourceAssembler.ToCommandFromResource(resource);

        var receptionStage = await wineBatchCommandService.Handle(command, batchId);

        if (receptionStage is null)
            return BadRequest("No se pudo actualizar la etapa de recepción.");
        
        // Mapear receptionStage a ReceptionStageResource
        var receptionStageResource = ReceptionStageResourceFromEntityAssembler.ToResourceFromEntity(receptionStage);
        
        return Ok(receptionStageResource);
    }
    
    
}