using Ardalis.Specification;

using BookLibrary.Db.Models;

using System;
using System.Linq;

namespace BookLibrary.Db.Specifications
{
    public class BookSpecification : Specification<Book>
    {
        public BookSpecification(Guid id) : base()
        {
            Query.Where(i => i.Id == id)
                .Include(i => i.Group)
                .Include(i => i.Authors)
                .Include(i => i.Files)
                .Include(i => i.Genres)
                .Include(i => i.Group);
        }
    }
}
