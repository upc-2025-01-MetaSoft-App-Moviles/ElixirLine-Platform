using ElixirLinePlatform.API.VinificationProcess.Domain.Model.AgriculturalActivities;
using ElixirLinePlatform.API.VinificationProcess.Domain.Repositories.AgriculturalActivities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ElixirLinePlatform.API.Shared.Domain.Repositories;

namespace ElixirLinePlatform.API.VinificationProcess.Domain.Services.AgriculturalActivities
{
    public class AgriculturalTaskService : IAgriculturalTaskService
    {
        private readonly IAgriculturalTaskRepository _taskRepository;
        
        private readonly IUnitOfWork _unitOfWork;
        
        public AgriculturalTaskService(IAgriculturalTaskRepository taskRepository, IUnitOfWork unitOfWork)
        {
            _taskRepository = taskRepository;
            _unitOfWork = unitOfWork;
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
            await _unitOfWork.CompleteAsync();
            return task;
        }

        public async Task<AgriculturalTask?> UpdateAsync(Guid id, AgriculturalTask task)
        {
            var existing = await _taskRepository.FindByIdAsync(id);
            if (existing == null) return null;

            existing.UpdateDetails(
                task.Title,
                task.Description,
                task.ParcelId,
                task.AssignedTo,
                task.ScheduledDate,
                task.Status
            );

            _taskRepository.Update(existing);
            await _unitOfWork.CompleteAsync();
            return existing;
        }

        public async Task<AgriculturalTask?> DeleteAsync(Guid id)
        {
            var existing = await _taskRepository.FindByIdAsync(id);
            if (existing == null) return null;

            _taskRepository.Remove(existing);
            await _unitOfWork.CompleteAsync();
            return existing;
        }
    }
}
