using ElixirLinePlatform.API.WinemakingProcess.Domain.Model.Entities;
using ElixirLinePlatform.API.WinemakingProcess.Domain.Model.ValueObjects;

namespace ElixirLinePlatform.API.VinificationProcess.Domain.Model.Aggregate;

public partial  class WineBatch
{
    public Guid Id { get; private set; }
    public string BatchCode { get; private set; } // Example: "B2024-VINEYARD01"
    public DateTime CreatedAt { get; private set; }
    public string CreatedBy { get; private set; }
    public string VineyardOrigin { get; private set; }
    public decimal InitialGrapeQuantityKg { get; private set; }
    public ProcessStatus Status { get; private set; } = ProcessStatus.Pending;
    public ProcessType? ProcessTypeWine { get; private set; }
    
    
    // Wine processing stages
    public Fermentation? Fermentation { get; private set; }
    public Pressing? Pressing { get; private set; }
    public Clarification? Clarification { get; private set; }
    public Aging? Aging { get; private set; }
    public Bottling? Bottling { get; private set; }

    private WineBatch() { }

    public WineBatch(string batchCode, string vineyardOrigin, decimal grapeQuantityKg, string createdBy)
    {
        Id = Guid.NewGuid();
        BatchCode = batchCode;
        VineyardOrigin = vineyardOrigin;
        InitialGrapeQuantityKg = grapeQuantityKg;
        CreatedBy = createdBy;
        CreatedAt = DateTime.UtcNow;
        
        // Set the initial status and process type
        Status = ProcessStatus.Pending;
        ProcessTypeWine = ProcessType.BatchReception;
    }

    // Methods to assign stages
    public void SetFermentation(Fermentation fermentation)
    {
        if (Fermentation != null)
            throw new InvalidOperationException("Fermentation has already been registered.");
        Fermentation = fermentation;
    }

    public void SetPressing(Pressing pressing)
    {
        if (Fermentation == null)
            throw new InvalidOperationException("Cannot start pressing before fermentation.");
        Pressing = pressing;
    }

    public void SetClarification(Clarification clarification)
    {
        if (Pressing == null)
            throw new InvalidOperationException("Cannot start clarification before pressing.");
        Clarification = clarification;
    }

    public void SetAging(Aging aging)
    {
        if (Clarification == null)
            throw new InvalidOperationException("Cannot start aging before clarification.");
        Aging = aging;
    }

    public void SetBottling(Bottling bottling)
    {
        if (Aging == null)
            throw new InvalidOperationException("Cannot start bottling before aging.");
        Bottling = bottling;
    }

    public bool IsCompleted()
    {
        return Fermentation != null &&
               Pressing != null &&
               Clarification != null &&
               Aging != null &&
               Bottling != null;
    }
    
}