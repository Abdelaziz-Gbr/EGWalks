using EGWalks.API.Data;
using EGWalks.API.Models.Domain;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace EGWalks.API.Repositories
{
    public class SqlWalkRepository : IWalkRepository
    {
        private readonly EGWalksDbContext dbContext;

        public SqlWalkRepository(EGWalksDbContext dbContext)
        {
            this.dbContext = dbContext;
        }


        public async Task<Walk> AddWalkAsync(Walk walk)
        {
            await dbContext.Walks.AddAsync(walk);
            await dbContext.SaveChangesAsync();
            var addedWalk = await dbContext.Walks.Include("Difficulty").Include("Region").FirstOrDefaultAsync(x => x.Id == walk.Id);
            return addedWalk;
        }

        public async Task<Walk?> DeleteWalkAsync(Guid id)
        {
            var walk = await dbContext.Walks
                .Include("Difficulty")
                .Include("Region")
                .FirstOrDefaultAsync(x => x.Id == id);

            if (walk == null)
            {
                return null;
            }

            dbContext.Walks.Remove(walk);
            await dbContext.SaveChangesAsync();
            return walk;
        }

        public async Task<List<Walk>> GetWalksAsync(
            string? FilterOn = null, string? FilterQuery = null,
            string? SortOn = null, bool Asc = true,
            int PageSize = 1000, int PageNo = 1)
        {
            var walks = dbContext.Walks.Include("Difficulty").Include("Region").AsQueryable();

            // filtering.
            if (!string.IsNullOrEmpty(FilterOn) && !string.IsNullOrEmpty(FilterQuery))
            {
                if (FilterOn.Equals("Name", StringComparison.OrdinalIgnoreCase))
                {
                    walks = walks.Where(walk => walk.Name.Contains(FilterQuery));
                }
            }

            // sorting.
            if(!string.IsNullOrWhiteSpace(SortOn))
            {
                if(SortOn.Equals("Name", StringComparison.OrdinalIgnoreCase))
                {
                    walks = Asc ? walks.OrderBy(walk => walk.Name) : walks.OrderByDescending(walk => walk.Name);
                }
                else if (SortOn.Equals("LengthInKm", StringComparison.OrdinalIgnoreCase))
                {
                    walks = Asc ? walks.OrderBy(walk => walk.LengthInKM) : walks.OrderByDescending(walk => walk.LengthInKM);
                }
            }
            // pagination
            var skip = (PageNo - 1) * PageSize;
            
            return await walks.Skip(skip).Take(PageSize).ToListAsync();
        }

        public async Task<Walk?> GetWalkByIdAsync(Guid id)
        {
            var walk = await dbContext.Walks.Include("Difficulty").Include("Region").FirstOrDefaultAsync(x => x.Id == id);
            return walk;
        }

        public async Task<Walk?> UpdateWalkAsync(Guid id, Walk walk)
        {
            var myWalk = await dbContext.Walks.FirstOrDefaultAsync(x => x.Id == id);
            if (myWalk == null)
                return null;
            myWalk.Update(walk);
            await dbContext.SaveChangesAsync();

            return await dbContext.Walks
                .Include("Difficulty")
                .Include("Region")
                .FirstOrDefaultAsync(x => x.Id == myWalk.Id);
        }
    }
}
