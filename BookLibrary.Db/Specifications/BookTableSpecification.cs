using Ardalis.Specification;

using BookLibrary.Db.Models;

namespace BookLibrary.Db.Specifications
{
    public class BookTableSpecification : Specification<Book>
    {
        public BookTableSpecification(int pageIndex, int pageSize) : base()
        {
            Query.OrderBy(i => i.CreationDate)
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize);
        }
    }
}
