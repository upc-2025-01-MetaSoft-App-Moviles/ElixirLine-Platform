namespace ElixirLinePlatform.API.WinemakingProcess.Domain.Model.Commands.AddStage;

public record AddFermentationStageCommand(
    string yeastUsed,
    double initialBrix,
    double finalBrix,
    double initialPh,
    double finalPh,
    double temperatureMax,
    double temperatureMin,
    string fermentationType,
    string tankCode,
    string startedAt,
    string? completedBy,
    string? observations);

    