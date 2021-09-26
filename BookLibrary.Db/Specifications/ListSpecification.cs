using Ardalis.Specification;

using BookLibrary.Db.Models;

using System;
using System.Collections.Generic;
using System.Linq;

namespace BookLibrary.Db.Specifications
{
    public class ListSpecification<T> : Specification<T> where T: IEntity
    {
        public ListSpecification(ICollection<Guid> uids) : base()
        {
            Query.Where(i => uids.Contains(i.Id));
        }
    }
}
