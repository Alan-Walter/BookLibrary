using BookLibrary.Db.Models;

using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace BookLibrary.Core.Services
{
    public interface IFileService
    {
        long MaxFileSize { get; }

        bool CanSave(string type, long fileSize);

        Task<string> SaveFileAsync(Func<Stream, CancellationToken, Task> saveFunc, Guid fileId);

        Stream OpenFile(string path);
    }
}
