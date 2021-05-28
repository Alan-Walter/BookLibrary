using System.IO;
using System.Threading.Tasks;

namespace BookLibrary.Core.Services
{
    public interface IFileService
    {
        long MaxFileSize { get; }

        bool CanSave(string fileName, string type);
    }
}
