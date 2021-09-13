using Ardalis.Specification;

using BookLibrary.Db.Models;

using System;
using System.Linq;
using System.Linq.Expressions;

namespace BookLibrary.Db.Specifications
{
    public class AuthorTableSpecification : Specification<Author>
    {
        public AuthorTableSpecification(int pageIndex, int pageSize, string propertyName, string direction) : base()
        {
            IOrderedSpecificationBuilder<Author> query;
            if (string.IsNullOrEmpty(direction) || direction == "ascend")
            {
                query = Query.OrderBy(PropertyExpression(propertyName));
            }
            else
            {
                query = Query.OrderByDescending(PropertyExpression(propertyName));
            }
            query.Skip((pageIndex - 1) * pageSize).Take(pageSize);
        }

        private static Expression<Func<Author, object>> PropertyExpression(string propertyName)
        {
            return propertyName switch
            {
                nameof(Author.FirstName) => x => x.FirstName,
                nameof(Author.MiddleName) => x => x.MiddleName,
                nameof(Author.LastName) => x => x.LastName,
                _ => x => x.FirstName,
            };
        }
    }
}
