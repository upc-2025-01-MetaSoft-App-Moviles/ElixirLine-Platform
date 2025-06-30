using ElixirLinePlatform.API.WinemakingProcess.Domain.Model.Aggregate;
using ElixirLinePlatform.API.WinemakingProcess.Domain.Model.Entities;
using ElixirLinePlatform.API.WinemakingProcess.Domain.Model.Queries;
using ElixirLinePlatform.API.WinemakingProcess.Domain.Repositories;
using ElixirLinePlatform.API.WinemakingProcess.Domain.Services;

namespace ElixirLinePlatform.API.WinemakingProcess.Application.Internal.QueryServices;

public class WineBatchQueryService(IWineBatchRepository wineBatchRepository) : IWineBatchQueryService
{

    // ============= OBTENER TODOS LOS LOTES DE VINO
    public async Task<IEnumerable<WineBatch>> Handle(GetAllWineBatchQuery query)
    {
        return await wineBatchRepository.ListAsync();
    }
    
    // ============= OBTENER TODAS LAS ETAPAS DE UN LOTE DE VINO
    public async Task<IEnumerable<WinemakingStage>> Handle(GetAllStagesByWineBatchIdQuery query)
    {
        return await wineBatchRepository.GetAllStagesByWineBatchIdAsync(query.Id);
    }
    

    // ============= OBTENER LOTE DE VINO POR ID
    public async Task<WineBatch?> Handle(GetWineBatchByIdQuery query)
    {
        return await wineBatchRepository.GetWineBatchByIdAsync(query.Id);
    }

    // ============= OBTENER LOTE DE VINO POR CODIGO INTERNO
    public async Task<ReceptionStage?> Handle(GetReceptionStageByWineBatchIdQuery query)
    {
        return await wineBatchRepository.GetReceptionStageByWineBatchIdAsync(query.Id);
    }
    
    // ============= OBTENER ETAPA DE FERMENTACION POR ID DE LOTE DE VINO
    public async Task<FermentationStage?> Handle(GetFermentationStageByWineBatchIdQuery query)
    {
        return await wineBatchRepository.GetFermentationStageByWineBatchIdAsync(query.Id);
    }

    // ============= OBTENER ETAPA DE PRENSADO POR ID DE LOTE DE VINO
    public async Task<PressingStage?> Handle(GetPressingStageByWineBatchIdQuery query)
    {
        return await wineBatchRepository.GetPressingStageByWineBatchIdAsync(query.Id);
    }
    
    // ============= OBTENER ETAPA DE CLARIFICACION POR ID DE
    public async Task<ClarificationStage?> Handle(GetClarificationStageByWineBatchIdQuery query)
    {
        return await wineBatchRepository.GetClarificationStageByWineBatchIdAsync(query.Id);
    }
    // ============= OBTENER ETAPA DE CORRECCION POR ID DE LOTE DE VINO
    public async Task<CorrectionStage?> Handle(GetCorrectionStageByWineBatchIdQuery query)
    {
        return await wineBatchRepository.GetCorrectionStageByWineBatchIdAsync(query.Id);
    }
    
    // ============= OBTENER ETAPA DE AGING POR ID DE LOTE DE VINO
    public async Task<AgingStage?> Handle(GetAgingStageByWineBatchIdQuery query)
    {
        return await wineBatchRepository.GetAgingStageByWineBatchIdAsync(query.Id);
    }
    
    // ============= OBTENER ETAPA DE FILTRACION POR ID DE LOTE DE VINO
    public async Task<FiltrationStage?> Handle(GetFiltrationStageByWineBatchIdQuery query)
    {
        return await wineBatchRepository.GetFiltrationStageByWineBatchIdAsync(query.Id);
    }
    
    // ============= OBTENER ETAPA DE EMBOTELLADO POR ID DE LOTE DE VINO
    public async Task<BottlingStage?> Handle(GetBottlingStageByWineBatchIdQuery query)
    {
        return await wineBatchRepository.GetBottlingStageByWineBatchIdAsync(query.Id);
    }
    
    
    
}