using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Utils;

namespace Services.Photo
{
    public class PhotoService : IPhotoService
    {
        public async Task<string> AddPhoto(IFormFile formFile)
        {
            string fileName = string.Empty;

            if (formFile != null)
            {
                fileName = $"{CryptHelper.CreateMD5(DateTime.Now.ToString())}{Path.GetExtension(formFile.FileName)}";
                var path = $"{Directory.GetCurrentDirectory()}/Files/";

                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);

                using (var fileStream = new FileStream(path + fileName, FileMode.Create))
                {
                    await formFile.CopyToAsync(fileStream);
                }
            }

            return fileName;
        }
    }
}
