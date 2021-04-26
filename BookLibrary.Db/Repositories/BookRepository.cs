using BookLibrary.Db.Interfaces;
using BookLibrary.Db.Models;

namespace BookLibrary.Db.Repositories
{
    public class BookRepository : AsyncRepository<Book>, IBookRepository
    {
        public BookRepository(ApplicationContext applicationContext) : base(applicationContext)
        {
        }
    }
}