using System.ComponentModel.DataAnnotations;

namespace EGWalks.API.Models.Dto
{
    public class AddRegionRequestDto
    {
        [Required(ErrorMessage = "Region Code is Required")]
        [Range(3,3, ErrorMessage ="Region Code Should be edxactly 3 characters long.")]
        public string Code { get; set; }

        [Required(ErrorMessage = "Region Code is Required")]
        public string Name { get; set; }

        public string? RegionImageUrl { get; set; }
    }
}
