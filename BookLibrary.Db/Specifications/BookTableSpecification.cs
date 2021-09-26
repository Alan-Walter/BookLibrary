using Ardalis.Specification;

using BookLibrary.Db.Models;

namespace BookLibrary.Db.Specifications
{
    public class BookTableSpecification : Specification<Book>
    {
        public BookTableSpecification(int pageIndex, int pageSize) : base()
        {
            if (pageIndex == 0)
            {
                pageIndex = 1;
            }

            if (pageSize == 0)
            {
                pageSize = 10;
            }

            Query.OrderBy(i => i.CreationDate)
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize)
                .Include(i => i.Authors)
                .Include(i => i.Genres)
                .Include(i => i.Group);
        }
    }
}
