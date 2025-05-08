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
            fermentation.YeastUsed,
            fermentation.InitialSugarLevel,
            fermentation.Temperature,
            fermentation.MalolacticFermentation,
            fermentation.TankCode
        );
    }
}