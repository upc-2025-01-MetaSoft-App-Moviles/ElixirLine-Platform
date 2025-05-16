using ElixirLinePlatform.API.VinificationProcess.Domain.Model.AgriculturalActivities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ElixirLinePlatform.API.VinificationProcess.Domain.Repositories.AgriculturalActivities
{
    public interface IParcelRepository
    {
        Task<IEnumerable<Parcel>> ListAsync();
        Task<Parcel?> FindByIdAsync(Guid parcelId);
        Task AddAsync(Parcel parcel);
        void Update(Parcel parcel);
        void Remove(Parcel parcel);
    }
}
