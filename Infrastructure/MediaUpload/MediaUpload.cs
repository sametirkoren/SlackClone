using Application.Interfaces;
using Application.MediaUpload;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;

namespace Infrastructure.MediaUpload
{
    public class MediaUpload : IMediaUpload
    {
        private readonly Cloudinary _clodinary;
        public MediaUpload(IOptions<CloudinarySettings> config)
        {
            var acc = new Account(config.Value.CloudName,config.Value.ApiKey,config.Value.ApiSecret);
            _clodinary = new Cloudinary(acc);
        }
        public MediaUploadResult UploadMedia(IFormFile file)
        {
            var uploadResult = new ImageUploadResult();

            if(file.Length > 0){
                using(var stream = file.OpenReadStream()){
                    var uploadParams = new ImageUploadParams{
                        File = new FileDescription(file.Name,stream)
                    };

                    uploadResult = _clodinary.Upload(uploadParams);
                }
            }

            if(uploadResult.Error !=null){
                throw new System.Exception(uploadResult.Error.Message);
            }

            return new MediaUploadResult{
                PublicId = uploadResult.PublicId,
                Url  = uploadResult.SecureUrl.AbsoluteUri
            };
        }
    }
}