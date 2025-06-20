using ElixirLinePlatform.API.VinificationProcess.Domain.Model.AgriculturalActivities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ElixirLinePlatform.API.VinificationProcess.Domain.Services.AgriculturalActivities
{
    public interface IAgriculturalTaskService
    {
        Task<IEnumerable<AgriculturalTask>> ListAsync();
        Task<AgriculturalTask?> GetByIdAsync(Guid id);
        Task<AgriculturalTask> CreateAsync(AgriculturalTask task);
        Task<AgriculturalTask?> UpdateAsync(Guid id, AgriculturalTask task);
        Task<AgriculturalTask?> DeleteAsync(Guid id);
    }
}
