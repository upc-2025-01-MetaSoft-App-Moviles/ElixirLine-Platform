using ElixirLinePlatform.API.VinificationProcess.Domain.Model.AgriculturalActivities;
using ElixirLinePlatform.API.VinificationProcess.Domain.Repositories.AgriculturalActivities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ElixirLinePlatform.API.Shared.Domain.Repositories;

namespace ElixirLinePlatform.API.VinificationProcess.Domain.Services.AgriculturalActivities
{
    public class ParcelService : IParcelService
    {
        private readonly IParcelRepository _parcelRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ParcelService(IParcelRepository parcelRepository, IUnitOfWork unitOfWork)
        {
            _parcelRepository = parcelRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Parcel>> ListAsync()
        {
            return await _parcelRepository.ListAsync();
        }

        public async Task<Parcel?> GetByIdAsync(Guid id)
        {
            return await _parcelRepository.FindByIdAsync(id);
        }

        public async Task<Parcel> CreateAsync(Parcel parcel)
        {
            await _parcelRepository.AddAsync(parcel);
            await _unitOfWork.CompleteAsync();
            return parcel;
        }

        public async Task<Parcel?> UpdateAsync(Guid id, Parcel parcel)
        {
            var existing = await _parcelRepository.FindByIdAsync(id);
            if (existing == null) return null;

            existing.Update(parcel.Name, parcel.Area, parcel.CropType, parcel.Location, parcel.Stage);
            _parcelRepository.Update(existing);
            await _unitOfWork.CompleteAsync();
            return existing;
        }

        public async Task<Parcel?> DeleteAsync(Guid id)
        {
            var existing = await _parcelRepository.FindByIdAsync(id);
            if (existing == null) return null;

            _parcelRepository.Remove(existing);
            await _unitOfWork.CompleteAsync();
            return existing;
        }
    }
}
