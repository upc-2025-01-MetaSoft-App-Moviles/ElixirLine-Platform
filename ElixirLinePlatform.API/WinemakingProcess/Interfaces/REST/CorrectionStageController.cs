﻿using ElixirLinePlatform.API.WinemakingProcess.Domain.Services;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace ElixirLinePlatform.API.WinemakingProcess.Interfaces.REST;


/*
[ApiController]
[Route("api/v1/wine-batches/{batchId:guid}/correction")]
[Produces("application/json")]
[SwaggerTag("Endpoints for managing the Correction Stage of a Wine Batch")]
public class CorrectionStageController(IWineBatchQueryService wineBatchQueryService, IWineBatchCommandService wineBatchCommandService): ControllerBase
{
    //=========== GET CORRECTION STAGE BY WINE BATCH ID
    [HttpGet]
    [SwaggerOperation(
        Summary = "Get Correction Stage by Wine Batch ID",
        Description = "Retrieves the Correction Stage associated with a specific Wine Batch.",
        OperationId = "GetCorrectionStageByWineBatchId")]
    [SwaggerResponse(StatusCodes.Status200OK, "The correction stage was successfully retrieved", typeof(CorrectionStageResource))]
    [SwaggerResponse(StatusCodes.Status404NotFound, "The wine batch or correction stage was not found")]
    public async Task<IActionResult> GetCorrectionStageByWineBatchId([FromRoute] Guid batchId)
    {
        var query = new GetCorrectionStageByWineBatchIdQuery(batchId);
        
        var correctionStage = await wineBatchQueryService.Handle(query);
        
        if (correctionStage == null)
            return NotFound("No se encontró la etapa de corrección para el lote de vino especificado.");
        
        // Mapear correctionStage a CorrectionStageResource
        var correctionStageResource = CorrectionStageResourceFromEntityAssembler.ToResourceFromEntity(correctionStage);
        
        return Ok(correctionStageResource);
    }
    
    // =========== POST CORRECTION
    [HttpPost]
    [SwaggerOperation(
        Summary = "Create a new Correction by Wine Batch",
        Description = "Create a new Correction by Wine Batch",
        OperationId = "CreateCorrectionByWineBatch")]
    [SwaggerResponse(StatusCodes.Status201Created, "The Correction was successfully created", typeof(CorrectionStageResource))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "The Correction was not created")]
    public async Task<IActionResult> AddCorrectionStageByBatch([FromBody] AddCorrectionStageResource resource, [FromRoute] Guid batchId)
    {
        var command = AddCorrectionStageByWineBatchCommandFromResourceAssembler.ToCommandFromResource(resource);

        var correctionStage = await wineBatchCommandService.Handle(command, batchId);

        if (correctionStage is null)
            return BadRequest("No se pudo agregar la etapa de corrección.");        
        
        
        
        var correctionStageResource = CorrectionStageResourceFromEntityAssembler.ToResourceFromEntity(correctionStage);
        
        
        return CreatedAtAction(nameof(GetCorrectionStageByWineBatchId), new { batchId }, correctionStageResource);
    }
}

*/

