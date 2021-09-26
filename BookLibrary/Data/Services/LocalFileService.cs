using BookLibrary.Core.Services;

using Microsoft.Extensions.Configuration;

using System;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BookLibrary.Data.Services
{
    public class LocalFileService : IFileService
    {
        const long maxFileSize = 100 * 1024 * 1024;

        private static readonly string[] allowedFiles = new[] { "application/pdf", "application/octet-stream" };

        private readonly string _filePath;

        public long MaxFileSize => maxFileSize;

        public LocalFileService(IConfiguration configuration)
        {
            _filePath = configuration.GetValue<string>("FilePath");
        }

        public bool CanSave(string type, long fileSize)
        {
            return !string.IsNullOrEmpty(_filePath) && fileSize < MaxFileSize && allowedFiles.Contains(type);
        }

        public async Task<string> SaveFileAsync(Func<Stream, CancellationToken, Task> saveFunc, Guid fileId)
        {
            var path = Path.Combine(_filePath, fileId.ToString());
            using var stream = File.Create(path);
            await saveFunc(stream, CancellationToken.None);
            return path;
        }

        public Stream OpenFile(string path)
        {
            return File.OpenRead(path);
        }
    }
}
