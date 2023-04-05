using API.Attributes;
using Entities.Enums;
using Microsoft.AspNetCore.Http;

namespace API.Models
{
    public class FileUploadModel
    {
        [FileExtension(FileType.Image)]

        [FileWeight(1024)]
        public IFormFile File { get; set; }
        public FileExtensionEnum FileExtension { get; set; }

    }


}
