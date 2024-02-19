using BlazorTopLearn_Server.Service.IService;
using Microsoft.AspNetCore.Components.Forms;

namespace BlazorTopLearn_Server.Service
{
    public class FileUploadService : IFileUploadService
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        public FileUploadService(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }
        public bool DeleteFile(string fileName)
        {
            try
            {
                var path = $"{_webHostEnvironment.WebRootPath}\\images\\news\\{fileName}";
                if (File.Exists(path))
                {
                    File.Delete(path);
                    return true;    
                }
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public async Task<string> UploadFile(IBrowserFile file)
        {
            try
            {
                FileInfo fileInfo = new FileInfo(file.Name);
                string fileName = Guid.NewGuid().ToString() + fileInfo.Extension;
                var folderDirectory = $"{_webHostEnvironment.WebRootPath}\\images\\news";
                var path = Path.Combine(_webHostEnvironment.WebRootPath, "images/news", file.Name);

                var memoryStream = new MemoryStream();
                await file.OpenReadStream().CopyToAsync(memoryStream);

                if (!Directory.Exists(folderDirectory))
                {
                    Directory.CreateDirectory(folderDirectory);
                }

                await using(var fs = new FileStream(path, FileMode.Create, FileAccess.Write))
                {
                    memoryStream.WriteTo(fs);
                }
                return fileName;

            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
