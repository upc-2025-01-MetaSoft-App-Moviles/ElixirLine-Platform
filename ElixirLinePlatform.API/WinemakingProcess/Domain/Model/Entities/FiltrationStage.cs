using System.Globalization;
using ElixirLinePlatform.API.WinemakingProcess.Domain.Model.Commands;
using ElixirLinePlatform.API.WinemakingProcess.Domain.Model.ValueObjects;

namespace ElixirLinePlatform.API.WinemakingProcess.Domain.Model.Entities;

public class FiltrationStage: WinemakingStage
{
    
     public string FiltrationType { get; private set; }     // Ej: "Filtración estéril"
    public string FilterMedia { get; private set; }        // Ej: "Membrana PES"
    public double PoreMicrons { get; private set; }        // Tamaño del poro en micras
    public double TurbidityBefore { get; private set; }    // NTU antes de filtrar
    public double TurbidityAfter { get; private set; }     // NTU después de filtrar
    public double Temperature { get; private set; }        // Temperatura durante la filtración
    public double PressureBars { get; private set; }       // Presión aplicada
    public double FilteredVolumeLiters { get; private set; } // Volumen filtrado
    public bool IsSterile { get; private set; }            // ¿Se garantiza esterilidad?
    public bool FilterChanged { get; private set; }        // ¿Se cambió el filtro?
    public string ChangeReason { get; private set; }       // Motivo del cambio

    
    
    public FiltrationStage() : base(StageType.Filtration, DateTime.Now, null)
    {
        FiltrationType = string.Empty;
        FilterMedia = string.Empty;
        PoreMicrons = 0;
        TurbidityBefore = 0;
        TurbidityAfter = 0;
        Temperature = 0;
        PressureBars = 0;
        FilteredVolumeLiters = 0;
        IsSterile = false;
        FilterChanged = false;
        ChangeReason = string.Empty;

        CompletedBy = null;
    }
    
    
    public FiltrationStage(
        string filtrationType,
        string filterMedia,
        double poreMicrons,
        double turbidityBefore,
        double turbidityAfter,
        double temperature,
        double pressureBars,
        double filteredVolumeLiters,
        bool isSterile,
        bool filterChanged,
        string changeReason,
        string startedAt,
        string? completedBy,
        string? observations
    ) : base(StageType.Filtration, ParseDate(startedAt), observations)
    {
        FiltrationType = filtrationType;
        FilterMedia = filterMedia;
        PoreMicrons = poreMicrons;
        TurbidityBefore = turbidityBefore;
        TurbidityAfter = turbidityAfter;
        Temperature = temperature;
        PressureBars = pressureBars;
        FilteredVolumeLiters = filteredVolumeLiters;
        IsSterile = isSterile;
        FilterChanged = filterChanged;
        ChangeReason = changeReason;

        CompletedBy = completedBy;
    }
    
    public FiltrationStage(AddFiltrationStageCommand command)
        : base(StageType.Filtration, ParseDate(command.startedAt), command.observations)
    {
        FiltrationType = command.filtrationType;
        FilterMedia = command.filterMedia;
        PoreMicrons = command.poreMicrons;
        TurbidityBefore = command.turbidityBefore;
        TurbidityAfter = command.turbidityAfter;
        Temperature = command.temperature;
        PressureBars = command.pressureBars;
        FilteredVolumeLiters = command.filteredVolumeLiters;
        IsSterile = command.isSterile;
        FilterChanged = command.filterChanged;
        ChangeReason = command.changeReason;

        CompletedBy = command.completedBy;
    }

    public override void Update(WinemakingStage updatedStage)
    {
        if (updatedStage is not FiltrationStage updated)
            throw new InvalidOperationException("Tipo incorrecto: se esperaba FiltrationStage.");

        FiltrationType = updated.FiltrationType;
        FilterMedia = updated.FilterMedia;
        PoreMicrons = updated.PoreMicrons;
        TurbidityBefore = updated.TurbidityBefore;
        TurbidityAfter = updated.TurbidityAfter;
        Temperature = updated.Temperature;
        PressureBars = updated.PressureBars;
        FilteredVolumeLiters = updated.FilteredVolumeLiters;
        IsSterile = updated.IsSterile;
        FilterChanged = updated.FilterChanged;
        ChangeReason = updated.ChangeReason;

        Observations = updated.Observations;
        CompletedAt = updated.CompletedAt;
        CompletedBy = updated.CompletedBy;
    }

    public override void Delete()
    {
        FiltrationType = string.Empty;
        FilterMedia = string.Empty;
        PoreMicrons = 0;
        TurbidityBefore = 0;
        TurbidityAfter = 0;
        Temperature = 0;
        PressureBars = 0;
        FilteredVolumeLiters = 0;
        IsSterile = false;
        FilterChanged = false;
        ChangeReason = string.Empty;

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