using ElixirLinePlatform.API.Shared.Domain.Repositories;
using ElixirLinePlatform.API.SupplyInventory.Domain.Model.Entities;
using ElixirLinePlatform.API.SupplyInventory.Domain.Repositories;
using ElixirLinePlatform.API.SupplyInventory.Domain.Services;
using ElixirLinePlatform.API.SupplyInventory.Domain.Services.Communication;

namespace ElixirLinePlatform.API.SupplyInventory.Services;

public class SupplyUsageService : ISupplyUsageService
{
    private readonly ISupplyUsageRepository _supplyUsageRepository;
    private readonly ISupplyRepository _supplyRepository;
    private readonly IUnitOfWork _unitOfWork;

    public SupplyUsageService(ISupplyUsageRepository supplyUsageRepository, ISupplyRepository supplyRepository, IUnitOfWork unitOfWork)
    {
        _supplyUsageRepository = supplyUsageRepository;
        _supplyRepository = supplyRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<SupplyUsage>> ListAsync()
    {
        return await _supplyUsageRepository.ListAsync();
    }

    public async Task<IEnumerable<SupplyUsage>> ListBySupplyIdAsync(int supplyId)
    {
        return await _supplyUsageRepository.ListBySupplyIdAsync(supplyId);
    }

    public async Task<IEnumerable<SupplyUsage>> ListByDateRangeAsync(DateTime startDate, DateTime endDate)
    {
        return await _supplyUsageRepository.ListByDateRangeAsync(startDate, endDate);
    }

    public async Task<SupplyUsageResponse> FindByIdAsync(int id)
    {
        var supplyUsage = await _supplyUsageRepository.FindByIdAsync(id);
        
        if (supplyUsage == null)
            return new SupplyUsageResponse("Registro de uso no encontrado");
            
        return new SupplyUsageResponse(supplyUsage);
    }

    public async Task<SupplyUsageResponse> SaveAsync(SupplyUsage supplyUsage)
    {
        // Verificar que el insumo existe
        var supply = await _supplyRepository.FindByIdAsync(supplyUsage.SupplyId);
        if (supply == null)
            return new SupplyUsageResponse("Insumo no encontrado");
            
        // Verificar que hay suficiente cantidad disponible
        if (supply.Quantity < supplyUsage.QuantityUsed)
            return new SupplyUsageResponse("Cantidad insuficiente de insumo disponible");
            
        try
        {
            // Actualizar la cantidad disponible del insumo
            supply.Quantity -= supplyUsage.QuantityUsed;
            _supplyRepository.Update(supply);
            
            // Guardar el registro de uso
            await _supplyUsageRepository.AddAsync(supplyUsage);
            await _unitOfWork.CompleteAsync();
            
            return new SupplyUsageResponse(supplyUsage);
        }
        catch (Exception ex)
        {
            return new SupplyUsageResponse($"Error al registrar el uso del insumo: {ex.Message}");
        }
    }

    public async Task<SupplyUsageResponse> UpdateAsync(int id, SupplyUsage supplyUsage)
    {
        var existingSupplyUsage = await _supplyUsageRepository.FindByIdAsync(id);
        
        if (existingSupplyUsage == null)
            return new SupplyUsageResponse("Registro de uso no encontrado");
            
        var supply = await _supplyRepository.FindByIdAsync(supplyUsage.SupplyId);
        if (supply == null)
            return new SupplyUsageResponse("Insumo no encontrado");
            
        // Calcular la diferencia de cantidad
        var quantityDifference = supplyUsage.QuantityUsed - existingSupplyUsage.QuantityUsed;
        
        // Verificar si hay suficiente cantidad disponible
        if (supply.Quantity < quantityDifference)
            return new SupplyUsageResponse("Cantidad insuficiente de insumo disponible");
            
        try
        {
            // Actualizar la cantidad disponible del insumo
            supply.Quantity -= quantityDifference;
            _supplyRepository.Update(supply);
            
            // Actualizar el registro de uso
            existingSupplyUsage.QuantityUsed = supplyUsage.QuantityUsed;
            existingSupplyUsage.UsageDate = supplyUsage.UsageDate;
            existingSupplyUsage.Notes = supplyUsage.Notes;
            
            _supplyUsageRepository.Update(existingSupplyUsage);
            await _unitOfWork.CompleteAsync();
            
            return new SupplyUsageResponse(existingSupplyUsage);
        }
        catch (Exception ex)
        {
            return new SupplyUsageResponse($"Error al actualizar el registro de uso: {ex.Message}");
        }
    }

    public async Task<SupplyUsageResponse> DeleteAsync(int id)
    {
        var existingSupplyUsage = await _supplyUsageRepository.FindByIdAsync(id);
        
        if (existingSupplyUsage == null)
            return new SupplyUsageResponse("Registro de uso no encontrado");
            
        var supply = await _supplyRepository.FindByIdAsync(existingSupplyUsage.SupplyId);
        if (supply == null)
            return new SupplyUsageResponse("Insumo no encontrado");
            
        try
        {
            // Devolver la cantidad al insumo
            supply.Quantity += existingSupplyUsage.QuantityUsed;
            _supplyRepository.Update(supply);
            
            // Eliminar el registro de uso
            _supplyUsageRepository.Remove(existingSupplyUsage);
            await _unitOfWork.CompleteAsync();
            
            return new SupplyUsageResponse(existingSupplyUsage);
        }
        catch (Exception ex)
        {
            return new SupplyUsageResponse($"Error al eliminar el registro de uso: {ex.Message}");
        }
    }
}
