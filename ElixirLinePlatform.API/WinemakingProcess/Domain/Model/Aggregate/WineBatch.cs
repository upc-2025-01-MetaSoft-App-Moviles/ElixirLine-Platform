using System.Globalization;
using ElixirLinePlatform.API.WinemakingProcess.Domain.Model.Commands;
using ElixirLinePlatform.API.WinemakingProcess.Domain.Model.Entities;
using ElixirLinePlatform.API.WinemakingProcess.Domain.Model.ValueObjects;

namespace ElixirLinePlatform.API.WinemakingProcess.Domain.Model.Aggregate;

public partial class WineBatch
{
    
    // ============== Datos propios de WineBatch
    public Guid Id { get; private set; } // ID único del lote
    
    public string UserId { get; private set; } // ID del usuario que creó el lote
    public string InternalCode { get; private set; } // Código interno visible para trazabilidad. Ej: "B2024-VINEYARD01"
    
    // ============== Datos de la campaña de cosecha (Integrar con el bounded context HarvestCampaign)
    public string CampaignId { get; private set; } // ID de la campaña de cosecha asociada
    public string HarvestCampaign { get; private set; } // Campaña de cosecha, Ej: "2024"
    public string VineyardOrigin { get; private set; } // Origen de las uvas
    public string GrapeVariety { get; private set; } // Variedad de uva (Malbec, etc.)
    public string CreatedBy { get; private set; } // Usuario que creó el lote
    public StageType CurrentStage { get; set; } // Etapa actual del proceso técnico (Reception, Fermentation, PressingStage, ClarificationStage, AgingStage, Correction, BottlingStage)

    // ============== Proceso técnico de vinificación
    public List<WinemakingStage> WinemakingStages { get; private set; } = new(); // Etapas del proceso
    
    
    // ============== Constructores

    public WineBatch()
    {
        CampaignId = "Hola";
        UserId = "user123"; // ID del usuario que creó el lote, se puede cambiar según la lógica de tu aplicación
        HarvestCampaign = string.Empty;
        VineyardOrigin = string.Empty;
        GrapeVariety = string.Empty;
        CreatedBy = string.Empty;
        InternalCode = string.Empty;
        CurrentStage = StageType.Reception;
    }

    public WineBatch(string internalCode, string receptionDate, string campaign, string vineyard, string grapeVariety, string createdBy, double initialGrapeQuantityKg)
        : this()
    {
        if (!DateTime.TryParseExact(receptionDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime parsedDate))
            throw new FormatException("La fecha debe estar en formato DD/MM/AAAA.");

        InternalCode = internalCode;
        HarvestCampaign = campaign;
        VineyardOrigin = vineyard;
        GrapeVariety = grapeVariety;
        CreatedBy = createdBy;
        CurrentStage = StageType.Reception;
    }

    
    
    public WineBatch(CreateWineBatchCommand command) : this()
    {
        InternalCode = command.internalCode;
        HarvestCampaign = command.campaign;
        VineyardOrigin = command.vineyard;
        GrapeVariety = command.grapeVariety;
        CreatedBy = command.createdBy;
        CurrentStage = StageType.Reception;
    }
    
    
    // ============== Comportamiento
    public void AddStage(WinemakingStage stage)
    {
        // Validaciones previas 
        if (WinemakingStages.Any(s => s.Id == stage.Id))
            throw new InvalidOperationException("Ya existe una etapa con el mismo ID.");

        if (WinemakingStages.Any(s => s.StageType == stage.StageType))
            throw new InvalidOperationException("Ya se ha registrado una etapa de este tipo.");

        // (Opcional) Validación de orden lógico entre etapas, si aplica
        stage.AssignBatchId(Id);
        WinemakingStages.Add(stage);
        CurrentStage = stage.StageType;
    }
    
    
    // ================== Actualizar una etapa de un lote de vino
    public void Update(UpdateWineBatchCommand command)
    {
        if (string.IsNullOrWhiteSpace(command.InternalCode))
            throw new ArgumentException("El código interno no puede estar vacío.", nameof(command.InternalCode));

        if (string.IsNullOrWhiteSpace(command.Campaign))
            throw new ArgumentException("La campaña no puede estar vacía.", nameof(command.Campaign));

        if (string.IsNullOrWhiteSpace(command.Vineyard))
            throw new ArgumentException("El viñedo no puede estar vacío.", nameof(command.Vineyard));

        if (string.IsNullOrWhiteSpace(command.GrapeVariety))
            throw new ArgumentException("La variedad de uva no puede estar vacía.", nameof(command.GrapeVariety));

        InternalCode = command.InternalCode;
        HarvestCampaign = command.Campaign;
        VineyardOrigin = command.Vineyard;
        GrapeVariety = command.GrapeVariety;
        CreatedBy = command.CreatedBy;
    }
    
    
    // ================== Retornar una etapa específica de un lote de vino
    public WinemakingStage GetStage(StageType stageType)
    {
        var stage = WinemakingStages.FirstOrDefault(s => s.StageType == stageType);

        if (stage == null)
            throw new InvalidOperationException("No se encontró la etapa especificada.");

        return stage;
    }
    
    
    // ================== Retornar todas las etapas de un lote de vino
    public IEnumerable<WinemakingStage> GetAllStages()
    {
        return WinemakingStages;
    }
    
    
    /// <summary>
    /// Marca el lote como completado.
    /// </summary>
    public void Complete()
    { 
        CurrentStage = StageType.Bottling;
    }
    
}