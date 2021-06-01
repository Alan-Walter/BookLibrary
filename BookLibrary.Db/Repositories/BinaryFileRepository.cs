using BookLibrary.Db.Interfaces;
using BookLibrary.Db.Models;

namespace BookLibrary.Db.Repositories
{
    public class BinaryFileRepository : AsyncRepository<BinaryFile>, IBinaryFileRepository
    {
        public BinaryFileRepository(ApplicationContext applicationContext) : base(applicationContext)
        {
        }
    }
}
