using System.Globalization;
using ElixirLinePlatform.API.WinemakingProcess.Domain.Model.Commands;
using ElixirLinePlatform.API.WinemakingProcess.Domain.Model.ValueObjects;

namespace ElixirLinePlatform.API.WinemakingProcess.Domain.Model.Entities;

public class BottlingStage : WinemakingStage
{
    
    public string BottlingLine { get; private set; }
    public int BottlesFilled { get; private set; }
    public int BottleVolumeMl { get; private set; }
    public double TotalVolumeLiters { get; private set; }
    public string SealType { get; private set; } // Ej: "Corcho natural"
    public string Code { get; private set; }     // Código de lote embotellado
    public double Temperature { get; private set; }

    public bool WasFiltered { get; private set; }
    public bool WereLabelsApplied { get; private set; }
    public bool WereCapsulesApplied { get; private set; }
    
    
    
    public BottlingStage() : base(StageType.Bottling, DateTime.Now, null)
    {
        BottlingLine = string.Empty;
        BottlesFilled = 0;
        BottleVolumeMl = 0;
        TotalVolumeLiters = 0;
        SealType = string.Empty;
        Code = string.Empty;
        Temperature = 0;
        WasFiltered = false;
        WereLabelsApplied = false;
        WereCapsulesApplied = false;

        CompletedBy = null;
    }
    
    
    
    
    public BottlingStage(
        string bottlingLine,
        int bottlesFilled,
        int bottleVolumeMl,
        double totalVolumeLiters,
        string sealType,
        string code,
        double temperature,
        bool wasFiltered,
        bool wereLabelsApplied,
        bool wereCapsulesApplied,
        string startedAt,
        string? completedBy,
        string? observations
    ) : base(StageType.Bottling, ParseDate(startedAt), observations)
    {
        BottlingLine = bottlingLine;
        BottlesFilled = bottlesFilled;
        BottleVolumeMl = bottleVolumeMl;
        TotalVolumeLiters = totalVolumeLiters;
        SealType = sealType;
        Code = code;
        Temperature = temperature;
        WasFiltered = wasFiltered;
        WereLabelsApplied = wereLabelsApplied;
        WereCapsulesApplied = wereCapsulesApplied;
        
        CompletedBy = completedBy;
    }
    
    
    public BottlingStage(AddBottlingStageCommand command) 
        : base(StageType.Bottling, ParseDate(command.startedAt), command.observations)
    {
        BottlingLine = command.bottlingLine;
        BottlesFilled = command.bottlesFilled;
        BottleVolumeMl = command.bottleVolumeMl;
        TotalVolumeLiters = command.totalVolumeLiters;
        SealType = command.sealType;
        Code = command.code;
        Temperature = command.temperature;
        WasFiltered = command.wasFiltered;
        WereLabelsApplied = command.wereLabelsApplied;
        WereCapsulesApplied = command.wereCapsulesApplied;

        CompletedBy = command.completedBy;
    }
    
    
    public override void Update(WinemakingStage updatedStage)
    {
        if (updatedStage is not BottlingStage updated)
            throw new InvalidOperationException("Tipo incorrecto: se esperaba BottlingStage.");

        BottlingLine = updated.BottlingLine;
        BottlesFilled = updated.BottlesFilled;
        BottleVolumeMl = updated.BottleVolumeMl;
        TotalVolumeLiters = updated.TotalVolumeLiters;
        SealType = updated.SealType;
        Code = updated.Code;
        Temperature = updated.Temperature;
        WasFiltered = updated.WasFiltered;
        WereLabelsApplied = updated.WereLabelsApplied;
        WereCapsulesApplied = updated.WereCapsulesApplied;

        Observations = updated.Observations;
        CompletedAt = updated.CompletedAt;
        CompletedBy = updated.CompletedBy;
    }

    public override void Delete()
    {
        BottlingLine = string.Empty;
        BottlesFilled = 0;
        BottleVolumeMl = 0;
        TotalVolumeLiters = 0;
        SealType = string.Empty;
        Code = string.Empty;
        Temperature = 0;
        WasFiltered = false;
        WereLabelsApplied = false;
        WereCapsulesApplied = false;

        Observations = null;
        CompletedAt = null;
        CompletedBy = null;
    }
    
    
    private static DateTime ParseDate(string date)
    {
        if (!DateTime.TryParseExact(date, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out var parsed))
            throw new FormatException("La fecha debe estar en formato dd/MM/yyyy.");
        return parsed;
    }
    
    public override void AssignBatchId(Guid batchId)
    {
        BatchId = batchId;
    }
    
}