namespace ElixirLinePlatform.API.WinemakingProcess.Domain.Model.Commands;

/*
 
   public string YeastUsed { get; private set; }
    public double Temperature { get; private set; }
    public double InitialSugarLevel { get; private set; }
    public double FinalSugarLevel { get; private set; }
    public double? InitialPH { get; private set; }
    public double? FinalPH { get; private set; }
    public double? maxFermentationTempC  {get; private set; }
    public double? minFermentationTempC {  get; private set; }
    public string fermentationType { get; private set; }
    public string TankCode { get; private set; }
    public bool fermentationCompleted { get; private set; }
    public bool MalolacticFermentation { get; private set; }
    
 */
public record AddFermentationStageCommand(
    string startedAt,
    string completedBy,
    string yeastUsed,
    double initialSugarLevel,
    double temperature,
    string tankCode,
    double initialPH,
    double finalPH,
    double maxFermentationTempC,
    double minFermentationTempC,
    string fermentationType,
    bool fermentationCompleted,
    string observations);

    