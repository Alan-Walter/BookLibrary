using BookLibrary.Db.Models;

namespace BookLibrary.Db.Interfaces
{
    public interface IAuthorRepository : IAsyncRepository<Author>
    {
    }
}
