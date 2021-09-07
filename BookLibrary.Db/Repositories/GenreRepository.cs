using BookLibrary.Db.Interfaces;
using BookLibrary.Db.Models;

namespace BookLibrary.Db.Repositories
{
    public class GenreRepository : AsyncRepository<Genre>, IGenreRepository
    {
        public GenreRepository(ApplicationContext applicationContext) : base(applicationContext)
        {
        }
    }
}
