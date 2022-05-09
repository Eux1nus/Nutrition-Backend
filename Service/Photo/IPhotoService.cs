using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Services.Photo
{
    public interface IPhotoService
    {
        Task<string> AddPhoto(IFormFile formFile);
    }
}
