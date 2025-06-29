using System.Globalization;
using ElixirLinePlatform.API.WinemakingProcess.Domain.Model.Commands;
using ElixirLinePlatform.API.WinemakingProcess.Domain.Model.Entities;
using ElixirLinePlatform.API.WinemakingProcess.Domain.Model.ValueObjects;

namespace ElixirLinePlatform.API.WinemakingProcess.Domain.Model.Aggregate;

public partial class WineBatch
{
    
    // ============== Datos propios de WineBatch
    public Guid Id { get; private set; } // ID único del lote
    public string InternalCode { get; private set; } // Código interno visible para trazabilidad. Ej: "B2024-VINEYARD01"
    
    // ============== Datos de la campaña de cosecha (Integrar con el bounded context HarvestCampaign)
    public string CampaignId { get; private set; } // ID de la campaña de cosecha asociada
    public DateTime ReceptionDate { get; private set; } // Fecha y hora de recepción
    public string HarvestCampaign { get; private set; } // Campaña de cosecha, Ej: "2024"
    public string VineyardOrigin { get; private set; } // Origen de las uvas
    public string GrapeVariety { get; private set; } // Variedad de uva (Malbec, etc.)
    public double InitialGrapeQuantityKg { get; private set; } // Cantidad inicial de uva en kg
    public string CreatedBy { get; private set; } // Usuario que creó el lote
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
    public void AddStage(WinemakingStage stage)
    {
        // Validaciones previas 
        if (WinemakingStages.Any(s => s.Id == stage.Id))
            throw new InvalidOperationException("Ya existe una etapa con el mismo ID.");

        if (WinemakingStages.Any(s => s.StageType == stage.StageType))
            throw new InvalidOperationException("Ya se ha registrado una etapa de este tipo.");

        // (Opcional) Validación de orden lógico entre etapas, si aplica
        WinemakingStages.Add(stage);
        CurrentStage = stage.StageType;
    }
    
    public void UpdateStage(WinemakingStage stage)
    {
        // Actualizar la etapa actual
        var existingStage = WinemakingStages.FirstOrDefault(s => s.Id == stage.Id);
        
        if (existingStage == null)
            throw new InvalidOperationException("La etapa especificada no existe en el lote.");
        
        if (existingStage.StageType != stage.StageType)
            throw new InvalidOperationException("No se puede cambiar el tipo de etapa una vez creada.");
        
        existingStage.Update(stage);

        // Si quieres reflejar la etapa como actual (en caso esta sea la última ingresada)
        if (CurrentStage == existingStage.StageType)
            CurrentStage = existingStage.StageType;
    }
    
    public void RemoveStage(Guid stageId)
    {
        var stageToRemove = WinemakingStages.FirstOrDefault(s => s.Id == stageId);

        if (stageToRemove == null)
            throw new InvalidOperationException("No se encontró la etapa a eliminar.");

        WinemakingStages.Remove(stageToRemove);

        // Si era la etapa actual, actualizamos al último Stage agregado (o a Reception)
        if (CurrentStage == stageToRemove.StageType)
            CurrentStage = WinemakingStages.LastOrDefault()?.StageType ?? StageType.Reception;
    }
    
    
    
    
    
    
    
    
    // ================== Retornar todas las etapas de un lote de vino
    public IEnumerable<WinemakingStage> GetAllStages()
    {
        return WinemakingStages;
    }
    

    public void CompleteStage(string stageName, DateTime completedAt)
    {
        var stage = WinemakingStages.FirstOrDefault(s => s.StageType.ToString() == stageName);

        if (stage == null)
            throw new InvalidOperationException("No se encontró la etapa.");

        stage.Complete(completedAt);
    }
    
    
    /// <summary>
    /// Marca el lote como completado.
    /// </summary>
    public void Complete()
    { 
        CurrentStage = StageType.Bottling;
    }

  
    
}