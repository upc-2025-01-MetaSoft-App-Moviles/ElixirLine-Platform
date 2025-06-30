using System.Net.Mime;
using ElixirLinePlatform.API.WinemakingProcess.Domain.Model.Entities;
using ElixirLinePlatform.API.WinemakingProcess.Domain.Model.Queries;
using ElixirLinePlatform.API.WinemakingProcess.Domain.Model.ValueObjects;
using ElixirLinePlatform.API.WinemakingProcess.Domain.Services;
using ElixirLinePlatform.API.WinemakingProcess.Interfaces.REST.Resources;
using ElixirLinePlatform.API.WinemakingProcess.Interfaces.REST.Resources.AddCommandStagesResources;
using ElixirLinePlatform.API.WinemakingProcess.Interfaces.REST.Transform;
using ElixirLinePlatform.API.WinemakingProcess.Interfaces.REST.Transform.CommandAssembler;
using ElixirLinePlatform.API.WinemakingProcess.Interfaces.REST.Transform.EntitiesAssembler;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace ElixirLinePlatform.API.WinemakingProcess.Interfaces.REST;

[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
[SwaggerTag("Endpoints for managing Wine Batches")]
public class WineBatchController(IWineBatchQueryService wineBatchQueryService, IWineBatchCommandService wineBatchCommandService): ControllerBase
{
    
    //=========== GET BATCH BY GUID
    [HttpGet("{id:guid}")]
    [SwaggerOperation(
        Summary = "Get a Batch by id",
        Description = "Get a Batch by id",
        OperationId = "GetBatchById"
        )]
    [SwaggerResponse(StatusCodes.Status200OK, "The Batch was successfully retrieved", typeof(WineBatchResource))]
    [SwaggerResponse(StatusCodes.Status404NotFound, "The Batch was not found")]
    public async Task<IActionResult> GetWineBatchById([FromRoute] Guid id)
    {
        var getWineBatchByIdQuery = new GetWineBatchByIdQuery(id);
        var wineBatch = await wineBatchQueryService.Handle(getWineBatchByIdQuery);

        if (wineBatch == null)
            return NotFound();
        
        // Mapear wineBatch a WineBatchResource
        var wineBatchResource = WineBatchResourceFromEntityAssembler.ToResourceFromEntity(wineBatch);

        return Ok(wineBatchResource); // <-- asegúrate de que wineBatch ya esté en formato WineBatchResource o mapea si es necesario
    }
    
    
    //=========== POST WINE BATCH
    [HttpPost]
    [SwaggerOperation(
        Summary = "Create a new Batch",
        Description = "Create a new Batch",
        OperationId = "CreateBatch"
        )]
    [SwaggerResponse(StatusCodes.Status201Created, "The Batch was successfully created", typeof(WineBatchResource))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "The Batch was not created")]
    public async Task<IActionResult> CreateBatch([FromBody] CreateWineBatchResource resource)
    {
        var createWineBatchCommand = CreateWineBatchCommandFromResourceAssembler.ToCommandFromResource(resource);
        
        var wineBatch = await wineBatchCommandService.Handle(createWineBatchCommand);

        if (wineBatch == null)
            return BadRequest();

        // Mapear wineBatch a WineBatchResource
        var wineBatchResource = WineBatchResourceFromEntityAssembler.ToResourceFromEntity(wineBatch);

        return CreatedAtAction(nameof(GetWineBatchById), new { id = wineBatch.Id }, wineBatchResource);
    }
    
    //=========== GET ALL WINE BATCHES
    [HttpGet]
    [SwaggerOperation(
        Summary = "Get All Wine Batches",
        Description = "Retrieves the complete list of registered wine batches.",
        OperationId = "GetAllWineBatches"
        )]
    [SwaggerResponse(StatusCodes.Status200OK, "Wine batches were successfully retrieved",
        typeof(IEnumerable<WineBatchResource>))]
    [SwaggerResponse(StatusCodes.Status404NotFound, "No wine batches found")]
    public async Task<IActionResult> GetAllWineBatches()
    {
        var query = new GetAllWineBatchQuery();
        
        var wineBatches = await wineBatchQueryService.Handle(query);
        
        if (!wineBatches.Any())
            return NotFound("No se encontraron lotes de vino registrados.");
        
        // Mapear wineBatches a IEnumerable<WineBatchResource>
        var wineBatchResources = wineBatches.Select(WineBatchResourceFromEntityAssembler.ToResourceFromEntity);
        
        return Ok(wineBatchResources);
    }
    
    // ========== GET ALL STAGES BY WINE BATCH ID 
    [HttpGet("{batchId:guid}/stages")]
    [SwaggerOperation(
        Summary = "Get all stages by Wine Batch ID",
        Description = "Retrieves all stages associated with a specific Wine Batch.",
        OperationId = "GetAllStagesByWineBatchId"
        )]
    [SwaggerResponse(StatusCodes.Status200OK, "The stages were successfully retrieved", typeof(IEnumerable<object>))]
    [SwaggerResponse(StatusCodes.Status404NotFound, "The wine batch or stages were not found")]
    public async Task<IActionResult> GetAllStagesByWineBatchId([FromRoute] Guid batchId)
    {
        var query = new GetAllStagesByWineBatchIdQuery(batchId);
        
        var stage = await wineBatchQueryService.Handle(query);

        // Mapear stage a IEnumerable<object>
        var stageResources = stage.Select(s =>
        {
            return s switch
            {
                ReceptionStage receptionStage => (object)ReceptionStageResourceFromEntityAssembler.ToResourceFromEntity(receptionStage)!,
                CorrectionStage correctionStage => (object)CorrectionStageResourceFromEntityAssembler.ToResourceFromEntity(correctionStage)!,
                FermentationStage fermentationStage => (object)FermentationStageResourceFromEntityAssembler.ToResourceFromEntity(fermentationStage)!,
                PressingStage pressingStage => (object)PressingStageResourceFromEntityAssembler.ToResourceFromEntity(pressingStage)!,
                ClarificationStage clarificationStage => (object)ClarificationStageResourceFromEntityAssembler.ToResourceFromEntity(clarificationStage)!,
                AgingStage agingStage => (object)AgingStageResourceFromEntityAssembler.ToResourceFromEntity(agingStage)!,
                FiltrationStage filtrationStage => (object)FiltrationStageResourceFromEntityAssembler.ToResourceFromEntity(filtrationStage)!,
                BottlingStage bottlingStage => (object)BottlingStageResourceFromEntityAssembler.ToResourceFromEntity(bottlingStage)!,
                _ => throw new InvalidOperationException($"Unknown stage type: {s.GetType().Name}")
            };
        });
        
      
        return Ok(stageResources);
    }
    
    
}