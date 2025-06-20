using ElixirLinePlatform.API.WinemakingProcess.Domain.Model.Entities;
using ElixirLinePlatform.API.WinemakingProcess.Interfaces.REST.Resources;

namespace ElixirLinePlatform.API.WinemakingProcess.Interfaces.REST.Transform;

public static class FermentationStageResourceFromEntityAssembler
{
    public static FermentationStageResource ToResourceFromEntity(WinemakingStage entity)
    {
        if (entity is not FermentationStage fermentation)
            throw new ArgumentException("La etapa no es de tipo ReceptionStage.");

        return new FermentationStageResource(
            fermentation.Id,
            fermentation.StartedAt.ToString("dd-MM-yyyy"),
            fermentation.CompletedBy,
            fermentation.YeastUsed,
            fermentation.InitialSugarLevel,
            fermentation.Temperature,
            fermentation.TankCode,
            fermentation.InitialPH,
            fermentation.FinalPH,
            fermentation.MaxFermentationTempC,
            fermentation.MinFermentationTempC,
            fermentation.FermentationType,
            fermentation.FermentationCompleted,
            fermentation.Observations
        );
    }
}