using ElixirLinePlatform.API.VinificationProcess.Domain.Model.AgriculturalActivities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ElixirLinePlatform.API.VinificationProcess.Domain.Repositories.AgriculturalActivities
{
    public interface IAgriculturalTaskRepository
    {
        Task<IEnumerable<AgriculturalTask>> ListAsync();
        Task<AgriculturalTask?> FindByIdAsync(Guid taskId);
        Task AddAsync(AgriculturalTask task);
        void Update(AgriculturalTask task);
        void Remove(AgriculturalTask task);
    }
}
