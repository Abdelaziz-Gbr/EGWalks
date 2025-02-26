using EGWalks.API.Models.Domain;
using EGWalks.API.Models.Dto;
using EGWalks.API.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EGWalks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : ControllerBase
    {
        private readonly IImageRepository imageRepository;

        public ImagesController(IImageRepository imageRepository)
        {
            this.imageRepository = imageRepository;
        }
        [HttpPost]
        [Route("upload")]
        public async Task<IActionResult> Upload([FromForm] ImageUploadRequestDto imageUploadRequest)
        {
            ValidateImage(imageUploadRequest);
            if (ModelState.IsValid) 
            {
                // add image.
                var imageDomainModel = new Image
                {
                    File = imageUploadRequest.File,
                    FileName = imageUploadRequest.FileName,
                    FileDescription = imageUploadRequest.FileDescrition,
                    FileExtension = Path.GetExtension(imageUploadRequest.File.FileName),
                };

                await imageRepository.Upload(imageDomainModel); 

                return CreatedAtAction(
                    nameof(Download),
                    new 
                    {
                        imageName = imageDomainModel.FileName + imageDomainModel.FileExtension 
                    },null);

            }

            return BadRequest(ModelState);
        }

        [HttpGet("{imageName}")]
        public IActionResult Download(string imageName)
        {
            var temp = imageName.Split('.');

            // Ensure valid format
            if (temp.Length < 2)
            {
                return BadRequest("Invalid file name format. Expected 'filename.ext'.");
            }

            var fileName = temp[0];
            var fileExt = temp[1];

            var fileStream = imageRepository.Download(fileName, fileExt);

            if (fileStream == null)
            {
                return NotFound("File not found.");
            }

            return File(fileStream, $"image/{fileExt}", $"{fileName}.{fileExt}");
        }

        private void ValidateImage(ImageUploadRequestDto imageUploadRequestDto) 
        {
            var acceptedExts = new string[] { ".png", ".jpeg", ".jpg" };
            if(!acceptedExts.Contains(Path.GetExtension(imageUploadRequestDto.File.FileName)))
            {
                ModelState.AddModelError("File Extenstion", "we don't support this file extenstion");
                return;
            }
            if(imageUploadRequestDto.File.Length > 10000000)
            {
                ModelState.AddModelError("File Size", "you must upload images less than 10MB");
                return;
            }
        }
    }
}
