using ElixirLinePlatform.API.VinificationProcess.Domain.Model.Aggregate;
using ElixirLinePlatform.API.WinemakingProcess.Domain.Model.Entities;
using ElixirLinePlatform.API.WinemakingProcess.Domain.Model.Queries;
using ElixirLinePlatform.API.WinemakingProcess.Domain.Repositories;
using ElixirLinePlatform.API.WinemakingProcess.Domain.Services;

namespace ElixirLinePlatform.API.WinemakingProcess.Application.Internal.QueryServices;

public class WineBatchQueryService(IWineBatchRepository wineBatchRepository) : IWineBatchQueryService
{

    public async Task<IEnumerable<WineBatch>> Handle(GetAllWineBatchQuery query)
    {
        return await wineBatchRepository.ListAsync();
    }

    public async Task<WineBatch?> Handle(GetWineBatchByIdQuery query)
    {
        return await wineBatchRepository.GetWineBatchByIdAsync(query.Id);
    }

    public async Task<ReceptionStage?> Handle(GetReceptionStageByWineBatchIdQuery query)
    {
        return await wineBatchRepository.GetReceptionStageByWineBatchIdAsync(query.Id);
    }

    public async Task<FermentationStage?> Handle(GetFermentationStageByWineBatchIdQuery query)
    {
        return await wineBatchRepository.GetFermentationStageByWineBatchIdAsync(query.Id);
    }

    public async Task<PressingStage?> Handle(GetPressingStageByWineBatchIdQuery query)
    {
        return await wineBatchRepository.GetPressingStageByWineBatchIdAsync(query.Id);
    }
}