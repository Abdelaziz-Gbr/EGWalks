﻿using EGWalks.API.Models.Domain;

namespace EGWalks.API.Repositories
{
    public interface IWalkRepository
    {
        Task<Walk> AddWalkAsync(Walk walk);

        Task<List<Walk>> GetAllWalksAsync();

        Task<Walk?> GetWalkByIdAsync(Guid id);

        Task<Walk?> UpdateWalkAsync(Guid id, Walk walk);

        Task<Walk?> DeleteWalkAsync(Guid id);
    }
}
