using ElixirLinePlatform.API.WinemakingProcess.Domain.Model.Entities;

namespace ElixirLinePlatform.API.WinemakingProcess.Domain.Model.Commands;

public record AddReceptionStageCommand(string startedAt, double sugarLevel, double pH, double temperature, double weightKg,string receivedBy, string? observations);