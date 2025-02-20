using EGWalks.API.Models.Domain;

namespace EGWalks.API.Repositories
{
    public interface IRegionRepository
    {
        Task<List<Region>> GetAllAsync();
        Task<Region?> GetByIdAsync(Guid id);
        Task<Region> AddRegionAsync(Region region);
        Task<Region?> UpdateRegionAsync(Guid id, Region region);
        Task<Region?> DeleteRegionAsync(Guid regionId);

    }
}
