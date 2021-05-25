using System.Collections.Generic;
using System.IO;

namespace BookLibrary.Core.Services
{
    public class LocalFileService : IFileService
    {
        const long maxFileSize = 10 * 1024 * 1024;

        private static readonly Dictionary<string, string> allowedFiles = new()
        {
            {".pdf", "application/pdf"},
            {".fb2", string.Empty }
        };

        public long MaxFileSize => maxFileSize;

        public bool CanSave(string fileName, string type)
        {
            var fileExt = Path.GetExtension(fileName);
            return allowedFiles.TryGetValue(fileExt, out var mimeType) && mimeType == type;
        }

        public (Stream, string) GetTemporaryFileStream()
        {
            var path = Path.GetTempFileName();
            return (File.OpenWrite(path), path);
        }
    }
}
