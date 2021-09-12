using Ardalis.Specification;

using BookLibrary.Db.Models;

using System;
using System.Linq;

namespace BookLibrary.Db.Specifications
{
    public class GenreWithoutBooksSpecification : Specification<Genre>
    {
        public GenreWithoutBooksSpecification(Guid id) : base()
        {
            Query.Where(i => i.Id == id && !i.Books.Any());
        }
    }
}
