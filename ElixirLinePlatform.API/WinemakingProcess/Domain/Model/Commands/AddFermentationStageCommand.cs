namespace ElixirLinePlatform.API.WinemakingProcess.Domain.Model.Commands;

public record AddFermentationStageCommand(string startedAt, string yeastUsed, double initialSugarLevel, double temperature, bool malo, string tankCode);