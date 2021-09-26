using BookLibrary.Db.Models;

using System.Threading.Tasks;

namespace BookLibrary.Db.Interfaces
{
    public interface IBinaryFileRepository : IAsyncRepository<BinaryFile>
    {
        Task RemoveBook(Book book);
    }
}