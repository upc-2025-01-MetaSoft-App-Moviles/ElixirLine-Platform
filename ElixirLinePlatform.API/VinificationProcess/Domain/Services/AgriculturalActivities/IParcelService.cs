using ElixirLinePlatform.API.VinificationProcess.Domain.Model.AgriculturalActivities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ElixirLinePlatform.API.VinificationProcess.Domain.Services.AgriculturalActivities
{
    public interface IParcelService
    {
        Task<IEnumerable<Parcel>> ListAsync();
        Task<Parcel?> GetByIdAsync(Guid id);
        Task<Parcel> CreateAsync(Parcel parcel);
        Task<Parcel?> UpdateAsync(Guid id, Parcel parcel);
        Task<Parcel?> DeleteAsync(Guid id);
    }
}
