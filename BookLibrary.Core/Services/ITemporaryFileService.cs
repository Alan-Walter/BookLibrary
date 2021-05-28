using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary.Core.Services
{
    public interface ITemporaryFileService
    {
        Task<string> SaveFile(Func<Stream, Task> saveAction);
    }
}
