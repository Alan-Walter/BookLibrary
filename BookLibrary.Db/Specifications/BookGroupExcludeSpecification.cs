using Ardalis.Specification;

using BookLibrary.Db.Models;

using System;
using System.Linq;

namespace BookLibrary.Db.Specifications
{
    public class BookGroupExcludeSpecification : Specification<BookGroup>
    {
        public BookGroupExcludeSpecification(Guid id) : base()
        {
            Query.Where(i => i.Id != id);
        }
    }
}
