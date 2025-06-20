using ElixirLinePlatform.API.VinificationProcess.Domain.Model.AgriculturalActivities;
using ElixirLinePlatform.API.VinificationProcess.Domain.Repositories.AgriculturalActivities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ElixirLinePlatform.API.VinificationProcess.Domain.Services.AgriculturalActivities
{
    public class ParcelService : IParcelService
    {
        private readonly IParcelRepository _parcelRepository;

        public ParcelService(IParcelRepository parcelRepository)
        {
            _parcelRepository = parcelRepository;
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
            return parcel;
        }

        public async Task<Parcel?> UpdateAsync(Guid id, Parcel parcel)
        {
            var existing = await _parcelRepository.FindByIdAsync(id);
            if (existing == null) return null;

            existing.UpdateCropType(parcel.CropType);
            _parcelRepository.Update(existing);
            return existing;
        }

        public async Task<Parcel?> DeleteAsync(Guid id)
        {
            var existing = await _parcelRepository.FindByIdAsync(id);
            if (existing == null) return null;

            _parcelRepository.Remove(existing);
            return existing;
        }
    }
}
