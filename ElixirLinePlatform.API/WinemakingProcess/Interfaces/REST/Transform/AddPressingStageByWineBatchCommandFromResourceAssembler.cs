﻿using ElixirLinePlatform.API.WinemakingProcess.Domain.Model.Commands;
using ElixirLinePlatform.API.WinemakingProcess.Interfaces.REST.Resources;

namespace ElixirLinePlatform.API.WinemakingProcess.Interfaces.REST.Transform;
    

public static class AddPressingStageByWineBatchCommandFromResourceAssembler
{
    public static AddPressingStageCommand ToCommandFromResource(AddPressingStageResource resource)
    {
        return new AddPressingStageCommand(
           resource.startedAt,
            resource.pressType,
            resource.maxPressureBar,
            resource.pressingDurationMinutes,
            resource.grapePomadeWeightKg,
            resource.extractedLiters,
            resource.intendedWineUse,
            resource.yieldPercentage,
            resource.completedBy,
            resource.observations   
           );
    }

    
}