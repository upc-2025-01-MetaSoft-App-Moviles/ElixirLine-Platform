using System.Globalization;
using ElixirLinePlatform.API.WinemakingProcess.Domain.Model.Commands;
using ElixirLinePlatform.API.WinemakingProcess.Domain.Model.Entities;
using ElixirLinePlatform.API.WinemakingProcess.Domain.Model.ValueObjects;

namespace ElixirLinePlatform.API.VinificationProcess.Domain.Model.Aggregate;

public partial  class WineBatch
{
    public Guid Id { get; private set; } // ID único del lote
    public string InternalCode  { get; private set; } // Código interno o visible para trazabilidad Example: "B2024-VINEYARD01"
    public DateTime ReceptionDate  { get; private set; } // Date and time of batch creation
    public string HarvestCampaign { get; private set; } // Example: "2024"
    public string VineyardOrigin { get; private set; } // Origin of the grapes
    public string GrapeVariety { get; private set; } // Variedad de uva (Malbec, etc.)
    public double InitialGrapeQuantityKg { get; private set; } // Initial quantity of grapes in kg
    public string CreatedBy { get; private set; } // User who created the batch 


    public BatchStatus? Status { get; private set; } // Estado actual del lote (Received, InProgress, Completed)

    public StageType CurrentStage => stagesWinemaking.LastOrDefault()?.StageType ?? StageType.Reception; // Status of the batch (Pending, Reception, Fermentation, Pressing, Clarification, Aging, Correction, Bottling)

    
    // Lista de etapas ya ejecutadas en este lote
    public List<WinemakingStage> stagesWinemaking { get; private set; } = new();
    
    
    //construstor de inicialización
    public WineBatch()
    {
        ReceptionDate = DateTime.Now;
        HarvestCampaign = string.Empty;
        VineyardOrigin = string.Empty;
        GrapeVariety = string.Empty;
        Status = BatchStatus.Received;
        CreatedBy = string.Empty;
        InternalCode = string.Empty;
        InitialGrapeQuantityKg = 0;
    }
    
    
    public WineBatch(string internalCode, string receptionDate, string campaign, string vineyard, string grapeVariety, string createdBy, double initialGrapeQuantityKg ): this()
    {
        
        if (!DateTime.TryParseExact(receptionDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime parsedDate))
        {
            throw new FormatException("La fecha debe estar en formato DD/MM/AAAA.");
        }
        Id = Guid.NewGuid();
        InternalCode = internalCode;
        ReceptionDate = parsedDate;
        HarvestCampaign = campaign;
        VineyardOrigin = vineyard;
        GrapeVariety = grapeVariety;
        Status = BatchStatus.Received;
        CreatedBy = createdBy;
        InitialGrapeQuantityKg = initialGrapeQuantityKg;
    }

    public WineBatch(CreateWineBatchCommand command): this()
    {
        Id = Guid.NewGuid();

        
        if (!DateTime.TryParseExact(command.receptionDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime parsedDate))
        {
            throw new FormatException("La fecha debe estar en formato DD/MM/AAAA.");
        }
        
        InternalCode = command.internalCode;
        ReceptionDate = parsedDate;
        HarvestCampaign = command.campaign;
        VineyardOrigin = command.vineyard;
        GrapeVariety = command.grapeVariety;
        Status = BatchStatus.Received;
        CreatedBy = command.createdBy;
        InitialGrapeQuantityKg = command.initialGrapeQuantityKg;
        
    }


    /// <summary>
    /// Agrega una nueva etapa técnica al proceso.
    /// </summary>
    public void AddStage(WinemakingStage stage)
    {
        
        stagesWinemaking.Add(stage);
        
        Status = BatchStatus.InProgress;
    }

    /// <summary>
    /// Marca el lote como completado al finalizar embotellado.
    /// </summary>
    public void Complete()
    {
        Status = BatchStatus.Completed;
    }

  
    
}