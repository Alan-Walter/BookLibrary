using BookLibrary.Db.Models;

namespace BookLibrary.Db.Interfaces
{
    public interface IBookRepository : IAsyncRepository<Book>
    {
    }
}