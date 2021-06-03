using Application.MediaUpload;
using Microsoft.AspNetCore.Http;

namespace Application.Interfaces
{
    public interface IMediaUpload
    {
         MediaUploadResult UploadMedia(IFormFile file);
    }
}