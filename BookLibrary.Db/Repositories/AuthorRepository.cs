using BookLibrary.Db.Interfaces;
using BookLibrary.Db.Models;

namespace BookLibrary.Db.Repositories
{
    public class AuthorRepository : AsyncRepository<Author>, IAuthorRepository
    {
        public AuthorRepository(ApplicationContext applicationContext) : base(applicationContext)
        {
        }
    }
}
