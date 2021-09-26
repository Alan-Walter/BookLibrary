using BookLibrary.Db.Interfaces;
using BookLibrary.Db.Models;

using Microsoft.EntityFrameworkCore;

using System.Threading.Tasks;

namespace BookLibrary.Db.Repositories
{
    public class BinaryFileRepository : AsyncRepository<BinaryFile>, IBinaryFileRepository
    {
        public BinaryFileRepository(ApplicationContext applicationContext) : base(applicationContext)
        {
        }

        public async Task RemoveBook(Book book)
        {
            await _dbContext.Database.ExecuteSqlRawAsync("Update \"BinaryFiles\" Set \"BookId\"=null where \"BookId\"={0}", book.Id);
        }
    }
}
