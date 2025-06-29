using System.Globalization;
using ElixirLinePlatform.API.WinemakingProcess.Domain.Model.Commands;
using ElixirLinePlatform.API.WinemakingProcess.Domain.Model.ValueObjects;

namespace ElixirLinePlatform.API.WinemakingProcess.Domain.Model.Entities;

public class ClarificationStage : WinemakingStage
{
    // ========== Propiedades de la clase ClarificationStage
    
 
    public string Method { get; private set; } // Ej: "Bentonita"
    //public List<ClarifyingAgent> ClarifyingAgents { get; private set; } = new();
    public double TurbidityBeforeNtu { get; private set; }
    public double TurbidityAfterNtu { get; private set; }
    public double VolumeLiters { get; private set; }
    public double Temperature { get; private set; }
    public int DurationHours { get; private set; }
    
    
    
    
    
    public ClarificationStage() : base(StageType.Clarification, DateTime.Now, null)
    {
        Method = string.Empty;
        //ClarifyingAgents = new();
        TurbidityBeforeNtu = 0;
        TurbidityAfterNtu = 0;
        VolumeLiters = 0;
        Temperature = 0;
        DurationHours = 0;
        
        CompletedBy = null;
    }
    
    
    
    public ClarificationStage(
        string method,
        /*List<ClarifyingAgent> clarifyingAgents,*/
        double turbidityBeforeNtu,
        double turbidityAfterNtu,
        double volumeLiters,
        double temperature,
        int durationHours,
        string startedAt,
        string? completedBy,
        string? observations
    ) : base(StageType.Clarification, ParseDate(startedAt), observations)
    {
        Method = method;
        //ClarifyingAgents = clarifyingAgents ?? new();
        TurbidityBeforeNtu = turbidityBeforeNtu;
        TurbidityAfterNtu = turbidityAfterNtu;
        VolumeLiters = volumeLiters;
        Temperature = temperature;
        DurationHours = durationHours;
        
        CompletedBy = completedBy;
    }
    
    public ClarificationStage(AddClarificationStageCommand command) 
        : base(StageType.Clarification, ParseDate(command.startedAt), command.observations)
    {
        Method = command.method;
        //ClarifyingAgents = command.clarifyingAgents ?? new();
        TurbidityBeforeNtu = command.turbidityBeforeNtu;
        TurbidityAfterNtu = command.turbidityAfterNtu;
        VolumeLiters = command.volumeLiters;
        Temperature = command.temperature;
        DurationHours = command.durationHours;
        
        CompletedBy = command.completedBy;
    }
    
    public override void Update(WinemakingStage updatedStage)
    {
        if (updatedStage is not ClarificationStage updated)
            throw new InvalidOperationException("Tipo incorrecto: se esperaba ClarificationStage.");

        Method = updated.Method;
        //ClarifyingAgents = updated.ClarifyingAgents;
        TurbidityBeforeNtu = updated.TurbidityBeforeNtu;
        TurbidityAfterNtu = updated.TurbidityAfterNtu;
        VolumeLiters = updated.VolumeLiters;
        Temperature = updated.Temperature;
        DurationHours = updated.DurationHours;

        Observations = updated.Observations;
        CompletedAt = updated.CompletedAt;
        CompletedBy = updated.CompletedBy;
    }

    public override void Delete()
    {
        Method = string.Empty;
        //ClarifyingAgents.Clear();
        TurbidityBeforeNtu = 0;
        TurbidityAfterNtu = 0;
        VolumeLiters = 0;
        Temperature = 0;
        DurationHours = 0;

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