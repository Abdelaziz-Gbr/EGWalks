using System.ComponentModel.DataAnnotations;

namespace EGWalks.API.Models.Dto
{
    public class AddWalkRequestDto
    {
        [Required(ErrorMessage ="Walk Name is required")]
        [Range(5,100, ErrorMessage = "Walk name should be greater than 4 characters and less than 100")]
        public string Name { get; set; }

        [Required(ErrorMessage ="you should provide a clear description for the walk")]
        public string Description { get; set; }

        [Range(0.1, 50, ErrorMessage ="Walk should be at least 100 meters long and less than 50 km")]
        public Double LengthInKM { get; set; }

        public string? WalkImageUrl { get; set; }

        [Required(ErrorMessage = "Walks should have difficulty")]
        public Guid DifficultyId { get; set; }

        [Required(ErrorMessage = "Walks should belong to a region")]
        public Guid RegionId { get; set; }
    }
}
