using EGWalks.API.Models.Domain;

namespace EGWalks.API.Models.Dto
{
    public class UpdateWalkDto
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public Double LengthInKM { get; set; }

        public string? WalkImageUrl { get; set; }

        public Guid DifficultyId { get; set; }

        public Guid RegionId { get; set; }
    }
}
