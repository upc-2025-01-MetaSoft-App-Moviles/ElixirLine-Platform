using ElixirLinePlatform.API.WinemakingProcess.Domain.Model.Entities;

namespace ElixirLinePlatform.API.WinemakingProcess.Domain.Model.Commands;

public record AddReceptionStageCommand( 
    double? sugarLevel, 
    double? pH, 
    double? temperature, 
    double? quantityKg, 
    string startedAt, 
    string? completedBy, 
    string? observations
    );

