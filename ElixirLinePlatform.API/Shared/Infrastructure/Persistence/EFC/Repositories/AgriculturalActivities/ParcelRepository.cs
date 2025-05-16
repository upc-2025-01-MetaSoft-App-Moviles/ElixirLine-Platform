using ElixirLinePlatform.API.VinificationProcess.Domain.Model.AgriculturalActivities;
using ElixirLinePlatform.API.VinificationProcess.Domain.Repositories.AgriculturalActivities;
using ElixirLinePlatform.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using Microsoft.EntityFrameworkCore;

namespace ElixirLinePlatform.API.VinificationProcess.Infrastructure.Persistence.EFC.Repositories.AgriculturalActivities
{
    public class ParcelRepository : IParcelRepository
    {
        private readonly AppDbContext _context;

        public ParcelRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Parcel>> ListAsync()
        {
            return await _context.Set<Parcel>().ToListAsync();
        }

        public async Task<Parcel?> FindByIdAsync(Guid parcelId)
        {
            return await _context.Set<Parcel>().FindAsync(parcelId);
        }

        public async Task AddAsync(Parcel parcel)
        {
            await _context.Set<Parcel>().AddAsync(parcel);
        }

        public void Update(Parcel parcel)
        {
            _context.Set<Parcel>().Update(parcel);
        }

        public void Remove(Parcel parcel)
        {
            _context.Set<Parcel>().Remove(parcel);
        }
    }
}
