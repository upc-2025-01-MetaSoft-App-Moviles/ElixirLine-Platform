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

    // Reemplazar los datos de una etapa existente en la lista de etapas del lote de vino.
    public void ReplaceStage(WinemakingStage updatedStage)
    {
        // Verificar si la etapa a reemplazar existe
        var existingStage = WinemakingStages.FirstOrDefault(s => s.Id == updatedStage.Id);
        
        // Si existe la etapa, buscar su indice para reemplazarla
        if (existingStage == null)
            throw new InvalidOperationException("No se encontró la etapa a reemplazar.");
        
        var index = WinemakingStages.IndexOf(existingStage);
        
        // Reemplazar la etapa en la lista
        WinemakingStages[index] = updatedStage;
    }
    
    //Asignar Lista de etapas a un lote de vino
    public void AssignStages(IEnumerable<WinemakingStage> stages)
    {
        if (stages == null || !stages.Any())
            throw new InvalidOperationException("La lista de etapas no puede estar vacía.");

        // Limpiar etapas existentes
        WinemakingStages.Clear();

        foreach (var stage in stages)
        {
            if (WinemakingStages.Any(s => s.Id == stage.Id))
                throw new InvalidOperationException("Ya existe una etapa con el mismo ID.");

            if (WinemakingStages.Any(s => s.StageType == stage.StageType))
                throw new InvalidOperationException("Ya se ha registrado una etapa de este tipo.");

            stage.AssignBatchId(Id);
            WinemakingStages.Add(stage);
        }

        // Actualizar la etapa actual al último agregado o a Reception si no hay etapas
        CurrentStage = WinemakingStages.LastOrDefault()?.StageType ?? StageType.Reception;
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
    
    // ================== Retornar una etapa específica de un lote de vino
    public WinemakingStage GetStage(StageType stageType)
    {
        var stage = WinemakingStages.FirstOrDefault(s => s.StageType == stageType);

        if (stage == null)
            throw new InvalidOperationException("No se encontró la etapa especificada.");

        return stage;
    }
 
    public bool ExistStage(StageType stageType)
    {
        return WinemakingStages.Any(s => s.StageType == stageType);
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