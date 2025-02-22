using EGWalks.API.Models.Domain;

namespace EGWalks.API.Models.Dto
{
    public class WalkDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public Double LengthInKM { get; set; }

        public string? WalkImageUrl { get; set; }

        public Difficulty Difficulty { get; set; }

        public Region Region { get; set; }

    }
}
