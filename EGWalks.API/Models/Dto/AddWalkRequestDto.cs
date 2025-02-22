namespace EGWalks.API.Models.Dto
{
    public class AddWalkRequestDto
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public Double LengthInKM { get; set; }

        public string? WalkImageUrl { get; set; }

        public Guid DifficultyId { get; set; }

        public Guid RegionId { get; set; }
    }
}
