using Ardalis.Specification;

using BookLibrary.Db.Models;

using System.Linq;

namespace BookLibrary.Core.Specifications
{
    public class AuthorListSpecification : Specification<Author>
    {
        public AuthorListSpecification(int pageSize, int pageIndex) : base()
        {
            Query.Skip(pageSize * pageIndex).Take(pageSize);
        }
    }
}
