using Ardalis.Specification;

using BookLibrary.Db.Models;

using System;
using System.Linq;

namespace BookLibrary.Db.Specifications
{
    public class BookGroupWithoutBooksAndChildsSpecification : Specification<BookGroup>
    {
        public BookGroupWithoutBooksAndChildsSpecification(Guid id) : base()
        {
            Query.Where(i => i.Id == id && !i.Childs.Any() && !i.Books.Any());
        }
    }
}
