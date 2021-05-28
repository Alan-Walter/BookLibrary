using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary.Core.Services
{
    public class TemporaryFileService : ITemporaryFileService
    {
        public async Task<string> SaveFile(Func<Stream, Task> saveAction)
        {
            var file = Path.GetTempFileName();
            using var stream = File.OpenWrite(file);
            await saveAction(stream);
            return file;
        }
    }
}
