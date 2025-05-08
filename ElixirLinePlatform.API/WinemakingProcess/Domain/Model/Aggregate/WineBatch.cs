using System.Globalization;
using ElixirLinePlatform.API.WinemakingProcess.Domain.Model.Commands;
using ElixirLinePlatform.API.WinemakingProcess.Domain.Model.Entities;
using ElixirLinePlatform.API.WinemakingProcess.Domain.Model.ValueObjects;

namespace ElixirLinePlatform.API.VinificationProcess.Domain.Model.Aggregate;

public partial class WineBatch
{
    
    // ============== Datos propios de WineBatch
    public Guid Id { get; private set; } // ID único del lote
    public string InternalCode { get; private set; } // Código interno visible para trazabilidad. Ej: "B2024-VINEYARD01"
    public DateTime ReceptionDate { get; private set; } // Fecha y hora de recepción
    public string HarvestCampaign { get; private set; } // Campaña de cosecha, Ej: "2024"
    public string VineyardOrigin { get; private set; } // Origen de las uvas
    public string GrapeVariety { get; private set; } // Variedad de uva (Malbec, etc.)
    public double InitialGrapeQuantityKg { get; private set; } // Cantidad inicial de uva en kg
    public string CreatedBy { get; private set; } // Usuario que creó el lote

    public BatchStatus? Status { get; private set; } // Estado del lote (Received, InProgress, Completed)
    public StageType CurrentStage { get; set; } // Etapa actual del proceso técnico (Reception, Fermentation, PressingStage, ClarificationStage, AgingStage, Correction, BottlingStage)

    // ============== Proceso técnico de vinificación
    public List<WinemakingStage> WinemakingStages { get; private set; } = new(); // Etapas del proceso
    
    
    
    // ============== Constructores

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
        CurrentStage = StageType.Reception;
    }

    public WineBatch(string internalCode, string receptionDate, string campaign, string vineyard, string grapeVariety, string createdBy, double initialGrapeQuantityKg)
        : this()
    {
        if (!DateTime.TryParseExact(receptionDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime parsedDate))
            throw new FormatException("La fecha debe estar en formato DD/MM/AAAA.");

        InternalCode = internalCode;
        ReceptionDate = parsedDate;
        HarvestCampaign = campaign;
        VineyardOrigin = vineyard;
        GrapeVariety = grapeVariety;
        CreatedBy = createdBy;
        InitialGrapeQuantityKg = initialGrapeQuantityKg;
        CurrentStage = StageType.Reception;
    }

    public WineBatch(CreateWineBatchCommand command) : this()
    {
        if (!DateTime.TryParseExact(command.receptionDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime parsedDate))
            throw new FormatException("La fecha debe estar en formato dd/MM/yyyy");

        InternalCode = command.internalCode;
        ReceptionDate = parsedDate;
        HarvestCampaign = command.campaign;
        VineyardOrigin = command.vineyard;
        GrapeVariety = command.grapeVariety;
        CreatedBy = command.createdBy;
        InitialGrapeQuantityKg = command.initialGrapeQuantityKg;
        CurrentStage = StageType.Reception;
    }
    
    
    
    // ============== Comportamiento

    /// <summary>
    /// Agrega una nueva etapa técnica al lote de vino.
    /// </summary>
    public void AddStage(WinemakingStage stage)
    {
        // Agregar a la colección general
        WinemakingStages.Add(stage);

        CurrentStage = stage.StageType;
        
        Status = BatchStatus.InProgress;
    }

    /// <summary>
    /// Marca el lote como completado.
    /// </summary>
    public void Complete()
    {
        Status = BatchStatus.Completed;
        CurrentStage = StageType.Bottling;
    }

  
    
}