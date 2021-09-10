using Ardalis.Specification;

using BookLibrary.Db.Models;

using System.Linq;

namespace BookLibrary.Db.Specifications
{
    public class RootBookGroupSpecification : Specification<BookGroup>
    {
        public RootBookGroupSpecification() : base()
        {
            Query.Where(i => i.Parent == null);
        }
    }
}
