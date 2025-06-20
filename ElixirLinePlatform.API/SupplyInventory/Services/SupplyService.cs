using ElixirLinePlatform.API.Shared.Domain.Repositories;
using ElixirLinePlatform.API.SupplyInventory.Domain.Model.Entities;
using ElixirLinePlatform.API.SupplyInventory.Domain.Repositories;
using ElixirLinePlatform.API.SupplyInventory.Domain.Services;
using ElixirLinePlatform.API.SupplyInventory.Domain.Services.Communication;

namespace ElixirLinePlatform.API.SupplyInventory.Services;

public class SupplyService : ISupplyService
{
    private readonly ISupplyRepository _supplyRepository;
    private readonly IUnitOfWork _unitOfWork;

    public SupplyService(ISupplyRepository supplyRepository, IUnitOfWork unitOfWork)
    {
        _supplyRepository = supplyRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Supply>> ListAsync()
    {
        return await _supplyRepository.ListAsync();
    }

    public async Task<IEnumerable<Supply>> ListByCategoryAsync(string category)
    {
        return await _supplyRepository.ListByCategoryAsync(category);
    }

    public async Task<IEnumerable<Supply>> ListByExpirationDateRangeAsync(DateOnly startDate, DateOnly endDate)
    {
        return await _supplyRepository.ListByExpirationDateRangeAsync(startDate, endDate);
    }

    public async Task<SupplyResponse> FindByIdAsync(int id)
    {
        var supply = await _supplyRepository.FindByIdAsync(id);
        
        if (supply == null)
            return new SupplyResponse("Insumo no encontrado");
            
        return new SupplyResponse(supply);
    }

    public async Task<SupplyResponse> SaveAsync(Supply supply)
    {
        try
        {
            await _supplyRepository.AddAsync(supply);
            await _unitOfWork.CompleteAsync();
            
            return new SupplyResponse(supply);
        }
        catch (Exception ex)
        {
            return new SupplyResponse($"Error al guardar el insumo: {ex.Message}");
        }
    }

    public async Task<SupplyResponse> UpdateAsync(int id, Supply supply)
    {
        var existingSupply = await _supplyRepository.FindByIdAsync(id);
        
        if (existingSupply == null)
            return new SupplyResponse("Insumo no encontrado");
            
        existingSupply.Name = supply.Name;
        existingSupply.Category = supply.Category;
        existingSupply.ExpirationDate = supply.ExpirationDate;
        existingSupply.Quantity = supply.Quantity;
        existingSupply.Unit = supply.Unit;
        
        try
        {
            _supplyRepository.Update(existingSupply);
            await _unitOfWork.CompleteAsync();
            
            return new SupplyResponse(existingSupply);
        }
        catch (Exception ex)
        {
            return new SupplyResponse($"Error al actualizar el insumo: {ex.Message}");
        }
    }

    public async Task<SupplyResponse> DeleteAsync(int id)
    {
        var existingSupply = await _supplyRepository.FindByIdAsync(id);
        
        if (existingSupply == null)
            return new SupplyResponse("Insumo no encontrado");
            
        try
        {
            _supplyRepository.Remove(existingSupply);
            await _unitOfWork.CompleteAsync();
            
            return new SupplyResponse(existingSupply);
        }
        catch (Exception ex)
        {
            return new SupplyResponse($"Error al eliminar el insumo: {ex.Message}");
        }
    }
}
