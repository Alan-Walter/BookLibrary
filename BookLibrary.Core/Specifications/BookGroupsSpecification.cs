using Ardalis.Specification;

using BookLibrary.Db.Models;

using System.Linq;

namespace BookLibrary.Core.Specifications
{
    public class BookGroupsSpecification : Specification<Book>
    {
        public BookGroupsSpecification() : base()
        {
            Query.Where(i => i.IsGroup);
        }
    }
}
