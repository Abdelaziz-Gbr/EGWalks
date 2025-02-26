using System.ComponentModel.DataAnnotations;

namespace EGWalks.API.Models.Dto
{
    public class ImageUploadRequestDto
    {
        [Required]
        public IFormFile File{ get; set; }

        [Required]
        public string FileName { get; set; }

        public string? FileDescrition { get; set; }
    }
}
