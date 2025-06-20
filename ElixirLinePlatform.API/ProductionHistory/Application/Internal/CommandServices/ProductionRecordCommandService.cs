using System.Globalization;
using ElixirLinePlatform.API.ProductionHistory.Domain.Model.Aggregate;
using ElixirLinePlatform.API.ProductionHistory.Domain.Model.Commands;
using ElixirLinePlatform.API.ProductionHistory.Domain.Repositories;
using ElixirLinePlatform.API.ProductionHistory.Domain.Services;
using ElixirLinePlatform.API.ProductionHistory.Infrastructure.Persistence.EFC.Repositories;
using ElixirLinePlatform.API.Shared.Domain.Repositories;

namespace ElixirLinePlatform.API.ProductionHistory.Application.Internal.CommandServices;

public class ProductionRecordCommandService(IProductionRecordRepository productionRecordRepository, IUnitOfWork unitOfWork) : IProductionRecordCommandService
{
    public async Task<ProductionRecord?> Handle(CreateProductionRecordCommand command)
    {
        // Validar que la fecha de inicio no sea posterior a la fecha de fin
        if (DateTime.TryParseExact(command.StartDate, "dd/MM/yyyy", CultureInfo.InvariantCulture,
                DateTimeStyles.None, out DateTime startDate) &&
            DateTime.TryParseExact(command.EndDate, "dd/MM/yyyy", CultureInfo.InvariantCulture,
                DateTimeStyles.None, out DateTime endDate))
        {
            if (startDate > endDate)
            {
                throw new ArgumentException("The start date cannot be later than the end date.");
            }
        }

        var productionRecord = new ProductionRecord(command);
        try
        {
            await productionRecordRepository.AddAsync(productionRecord);
            await unitOfWork.CompleteAsync();
            return productionRecord;
        }
        catch (Exception e)
        {
            Console.WriteLine($"An error occurred while creating the production record: {e.Message}");
            return null;
        }
    }

    public async Task<ProductionRecord?> Handle(UpdateVolumeProducedCommand command)
    {
        var productionRecord = await productionRecordRepository.GetProductionRecordByIdAsync(command.recordID);
        if (productionRecord is null)
        {
            throw new Exception($"No production record found with ID: {command.recordID}");
        }
    
        try
        {
            productionRecord.UpdateVolumeProduced(command.VolumeProduced);
            await unitOfWork.CompleteAsync();
            return productionRecord;
        }
        catch (Exception e)
        {
            Console.WriteLine($"An error occurred while updating the production record: {e.Message}");
            return null;
        }
    }

    public async Task<bool> Handle(DeleteProductionRecordCommand command)
    {
        var productionRecord = await productionRecordRepository.GetProductionRecordByIdAsync(command.RecordId);
        if (productionRecord is null)
        {
            throw new Exception($"No production record found with ID: {command.RecordId}");
        }
        try
        {
            productionRecordRepository.Remove(productionRecord);
            await unitOfWork.CompleteAsync();
            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine($"An error occurred while deleting the production record: {e.Message}");
            return false;
        }
    }
    
}