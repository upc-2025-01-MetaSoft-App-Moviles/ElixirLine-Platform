using ElixirLinePlatform.API.WinemakingProcess.Domain.Model.Entities;

namespace ElixirLinePlatform.API.WinemakingProcess.Domain.Model.Commands;

public record AddReceptionStageCommand(string startedAt, string completedBy, double sugarLevel, double pH, double temperature, double weightKg, string? observations);