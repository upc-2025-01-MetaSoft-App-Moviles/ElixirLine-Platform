using System.Net.Mime;
using ElixirLinePlatform.API.ProductionHistory.Domain.Model.Commands;
using ElixirLinePlatform.API.ProductionHistory.Domain.Model.Queries;
using ElixirLinePlatform.API.ProductionHistory.Domain.Services;
using ElixirLinePlatform.API.ProductionHistory.Interfaces.REST.Resources;
using ElixirLinePlatform.API.ProductionHistory.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace ElixirLinePlatform.API.ProductionHistory.Interfaces.REST;

[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
[SwaggerTag("Available Production History Endpoints")]
public class ProductionRecordController(IProductionRecordQueryService productionRecordQueryService, IProductionRecordCommandService productionRecordCommandService): ControllerBase
{
    [HttpGet("{recordId:guid}")]
    [SwaggerOperation(
        Summary = "Get a Production Record by RecordId",
        Description = "Get a Production by id",
        OperationId = "GetProductionRecordById"
    )]
    [SwaggerResponse(StatusCodes.Status200OK, "The Production Record was successfully retrieved", typeof(ProductionRecordResource))]
    [SwaggerResponse(StatusCodes.Status404NotFound, "The Production Record was not found")]
    public async Task<IActionResult> GetProductionRecordById([FromRoute] Guid recordId)
    {
        var getProductionRecordByIdQuery = new GetProductionRecordByIdQuery(recordId);
        var productionRecord = await productionRecordQueryService.Handle(getProductionRecordByIdQuery);
        
        if (productionRecord == null)
        {
            return NotFound();
        }

        var productionRecordResource = ProductionRecordFromEntityAssembler.ToResourceFromEntity(productionRecord);
        
        return Ok(productionRecordResource);
    }

    [HttpGet("batch/{batchId:guid}")]
    [SwaggerOperation(
        Summary = "Get a Production Record by BatchId",
        Description = "Get a Production by Batchid",
        OperationId = "GetProductionRecordByBatchId"
    )]
    [SwaggerResponse(StatusCodes.Status200OK, "The Production Record by Batch was successfully retrieved", typeof(ProductionRecordResource))]
    [SwaggerResponse(StatusCodes.Status404NotFound, "The Production Record by Batch was not found")]
    public async Task<IActionResult> GetAllProductionRecordsByBatchId([FromRoute] Guid batchId)
    {
        var getAllProductionRecordsByBatchIdQuery = new GetAllProductionRecordByBatchIdQuery(batchId);
        var productionRecords = await productionRecordQueryService.Handle(getAllProductionRecordsByBatchIdQuery);
        
        if (productionRecords == null || !productionRecords.Any())
        {
            return NotFound("No Production Records found for the given Batch ID");
        }
        
        var productionRecordResources = productionRecords.Select(ProductionRecordFromEntityAssembler.ToResourceFromEntity);

        return Ok(productionRecordResources);
    }

    [HttpGet]
    [SwaggerOperation(
        Summary = "Get All Production Records",
        Description = "Retrieves the complete list of registered Production Records.",
        OperationId = "GetAllProduction Records")]
    [SwaggerResponse(StatusCodes.Status200OK, "Production Records were successfully retrieved", 
        typeof(IEnumerable<ProductionRecordResource>))]
    [SwaggerResponse(StatusCodes.Status404NotFound, "No Production Records found")]
    public async Task<IActionResult> GetAllProductionRecords()
    {
        var getAllProductionRecordsQuery = new GetAllProductionRecordQuery();
        
        var productionRecords = await productionRecordQueryService.Handle(getAllProductionRecordsQuery);
        
        if (productionRecords == null || !productionRecords.Any())
        {
            return NotFound("No Production Records found");
        }
        var productionRecordResources = productionRecords.Select(ProductionRecordFromEntityAssembler.ToResourceFromEntity);

        return Ok(productionRecordResources);
    }

    [HttpPost]
    [SwaggerOperation(
        Summary = "Create a new Production Record",
        Description = "Create a new Production Record",
        OperationId = "CreateProductionRecord"
    )]
    [SwaggerResponse(StatusCodes.Status201Created, "The Production Record was successfully created",
        typeof(ProductionRecordResource))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "The Production Record was not created")]
    public async Task<IActionResult> CreateProductionRecord([FromBody] CreateProductionRecordResource resource)
    {
        var createProductionRecordCommand =
            CreateProductionRecordCommandFromResourceAssembler.ToCommandFromResource(resource);
        var productionRecord = await productionRecordCommandService.Handle(createProductionRecordCommand);

        if (productionRecord == null)
        {
            return BadRequest("Failed to create production record");
        }

        var productionRecordResource = ProductionRecordFromEntityAssembler.ToResourceFromEntity(productionRecord);
        return CreatedAtAction(nameof(GetProductionRecordById), new { recordId = productionRecordResource.RecordId },
            productionRecordResource);
    }

    [HttpPut("{recordId:guid}/volume")]
    [SwaggerOperation(
        Summary = "Update the volume produced for a Production Record",
        Description = "Updates the volume produced for an existing Production Record",
        OperationId = "UpdateProductionRecordVolume"
    )]
    [SwaggerResponse(StatusCodes.Status200OK, "The Production Record volume was successfully updated", 
        typeof(ProductionRecordResource))]
    [SwaggerResponse(StatusCodes.Status404NotFound, "The Production Record was not found")]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "The Production Record volume update failed")]
    public async Task<IActionResult> UpdateProductionRecordVolume([FromRoute] Guid recordId, [FromBody] UpdateVolumeProducedResource resource)
    {
        var updateVolumeProducedCommand = UpdateVolumeProducedCommandFromResourceAssembler.ToCommandFromResource(recordId, resource);
        var productionRecord = await productionRecordCommandService.Handle(updateVolumeProducedCommand);
        if (productionRecord == null)
        {
            return BadRequest("Failed to update production record volume");
        }
        var productionRecordResource = ProductionRecordFromEntityAssembler.ToResourceFromEntity(productionRecord);
        return Ok(productionRecordResource);
    }

    [HttpDelete("{recordId:guid}")]
    [SwaggerOperation(
        Summary = "Delete a Production Record",
        Description = "Deletes an existing Production Record",
        OperationId = "DeleteProductionRecord"
    )]
    [SwaggerResponse(StatusCodes.Status204NoContent, "The Production Record was successfully deleted")]
    [SwaggerResponse(StatusCodes.Status404NotFound, "The Production Record was not found")]
    public async Task<IActionResult> DeleteProductionRecord([FromRoute] Guid recordId)
    {
        var deleteProductionRecordCommand = new DeleteProductionRecordCommand(recordId);

        try
        {
            var result = await productionRecordCommandService.Handle(deleteProductionRecordCommand);

            if (!result)
            {
                return BadRequest("Failed to delete production record");
            }

            return NoContent();
        }
        catch (Exception ex)
        {
            return NotFound(ex.Message);
        }
    }
}