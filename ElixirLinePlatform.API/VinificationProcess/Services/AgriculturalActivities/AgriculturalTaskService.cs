using ElixirLinePlatform.API.VinificationProcess.Domain.Model.AgriculturalActivities;
using ElixirLinePlatform.API.VinificationProcess.Domain.Repositories.AgriculturalActivities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ElixirLinePlatform.API.VinificationProcess.Domain.Services.AgriculturalActivities
{
    public class AgriculturalTaskService : IAgriculturalTaskService
    {
        private readonly IAgriculturalTaskRepository _taskRepository;

        public AgriculturalTaskService(IAgriculturalTaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public async Task<IEnumerable<AgriculturalTask>> ListAsync()
        {
            return await _taskRepository.ListAsync();
        }

        public async Task<AgriculturalTask?> GetByIdAsync(Guid id)
        {
            return await _taskRepository.FindByIdAsync(id);
        }

        public async Task<AgriculturalTask> CreateAsync(AgriculturalTask task)
        {
            await _taskRepository.AddAsync(task);
            return task;
        }

        public async Task<AgriculturalTask?> UpdateAsync(Guid id, AgriculturalTask task)
        {
            var existing = await _taskRepository.FindByIdAsync(id);
            if (existing == null) return null;

            existing.CancelTask("Actualización manual - cancela antes de modificar");
            existing = task;

            _taskRepository.Update(existing);
            return existing;
        }

        public async Task<AgriculturalTask?> DeleteAsync(Guid id)
        {
            var existing = await _taskRepository.FindByIdAsync(id);
            if (existing == null) return null;

            _taskRepository.Remove(existing);
            return existing;
        }
    }
}
