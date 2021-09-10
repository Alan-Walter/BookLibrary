using Ardalis.Specification;

using BookLibrary.Db.Models;

using System;
using System.Linq;

namespace BookLibrary.Db.Specifications
{
    public class ChildsBookGroupSpecification : Specification<BookGroup>
    {
        public ChildsBookGroupSpecification(Guid parentId) : base()
        {
            Query.Where(i => i.Parent.Id == parentId);
        }
    }
}
