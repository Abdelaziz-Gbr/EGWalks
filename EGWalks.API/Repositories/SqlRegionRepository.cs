using EGWalks.API.Data;
using EGWalks.API.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace EGWalks.API.Repositories
{
    public class SqlRegionRepository : IRegionRepository
    {
        EGWalksDbContext dbContext;

        public SqlRegionRepository(EGWalksDbContext dbContext) => 
            this.dbContext = dbContext;
        public async Task<Region> AddRegionAsync(Region region)
        {
            await dbContext.Regions.AddAsync(region);
            await dbContext.SaveChangesAsync();
            return region;
        }

        public async Task<Region?> DeleteRegionAsync(Guid regionId)
        {
            var region = await dbContext.Regions.FirstOrDefaultAsync( x => x.Id == regionId);
            if(region == null)
            {
                return null;
            }
            dbContext.Regions.Remove(region);
            await dbContext.SaveChangesAsync();
            return region;
        }

        public async Task<List<Region>> GetAllAsync()
        {
            var Regions = await dbContext.Regions.ToListAsync();
            return Regions;
        }

        public async Task<Region?> GetByIdAsync(Guid id)
        {
            var region = await dbContext.Regions.FirstOrDefaultAsync(region => region.Id == id);
            return region;
        }

        public async Task<Region?> UpdateRegionAsync(Guid id, Region region)
        {
            var regionModel = await dbContext.Regions.FirstOrDefaultAsync(r => r.Id == id);
            if (regionModel == null)
            {
                return null;
            }
            regionModel.Update(region);
            await dbContext.SaveChangesAsync();
            return regionModel;
            

        }
    }
}
