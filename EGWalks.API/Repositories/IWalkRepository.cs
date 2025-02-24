using EGWalks.API.Models.Domain;

namespace EGWalks.API.Repositories
{
    public interface IWalkRepository
    {
        Task<Walk> AddWalkAsync(Walk walk);

        Task<List<Walk>> GetWalksAsync(
            string? FilterOn = null, string? FilterQuery = null,
            string? SortOn = null, bool Asc = true,
            int PageSize = 1000, int PageNo = 1);

        Task<Walk?> GetWalkByIdAsync(Guid id);

        Task<Walk?> UpdateWalkAsync(Guid id, Walk walk);

        Task<Walk?> DeleteWalkAsync(Guid id);
    }
}
