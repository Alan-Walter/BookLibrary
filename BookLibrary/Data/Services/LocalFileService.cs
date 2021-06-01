using BookLibrary.Core.Services;

using Microsoft.AspNetCore.Hosting;

using System.Collections.Generic;
using System.IO;

namespace BookLibrary.Data.Services
{
    public class LocalFileService : IFileService
    {
        readonly IWebHostEnvironment webHostEnvironment;

        const string BookDirectory = "Books";

        const long maxFileSize = 10 * 1024 * 1024;

        private static readonly Dictionary<string, string> allowedFiles = new()
        {
            { ".pdf", "application/pdf" },
            { ".fb2", string.Empty }
        };

        public long MaxFileSize => maxFileSize;

        public LocalFileService(IWebHostEnvironment webHostEnvironment)
        {
            this.webHostEnvironment = webHostEnvironment;
        }

        public bool CanSave(string fileName, string type)
        {
            var fileExt = Path.GetExtension(fileName);
            return allowedFiles.TryGetValue(fileExt, out var mimeType) && mimeType == type;
        }

        public string SaveFile(string tempFileName, string fileName)
        {
            var dirPath = Path.Combine(webHostEnvironment.ContentRootPath, BookDirectory);
            var file = Path.GetRandomFileName() + "_" + fileName;
            var path = Path.Combine(dirPath, file);
            File.Copy(tempFileName, path);
            return path;
        }
    }
}
