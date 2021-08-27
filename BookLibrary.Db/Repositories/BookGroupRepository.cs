using BookLibrary.Db.Interfaces;
using BookLibrary.Db.Models;

namespace BookLibrary.Db.Repositories
{
    public class BookGroupRepository : AsyncRepository<BookGroup>, IBookGroupRepository
    {
        public BookGroupRepository(ApplicationContext applicationContext) : base(applicationContext)
        {
        }
    }
}
