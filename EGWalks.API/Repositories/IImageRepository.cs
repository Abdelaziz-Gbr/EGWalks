using EGWalks.API.Models.Domain;

namespace EGWalks.API.Repositories
{
    public interface IImageRepository
    {
        Task<Image> Upload(Image image);

        FileStream? Download(string fileName, string fileExt);
    }
}
