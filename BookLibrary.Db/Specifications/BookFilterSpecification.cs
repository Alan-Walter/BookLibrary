using Ardalis.Specification;

using BookLibrary.Db.Models;

using System;
using System.Collections.Generic;
using System.Linq;

namespace BookLibrary.Db.Specifications
{
    public class BookFilterSpecification : Specification<Book>
    {
        public BookFilterSpecification(int pageIndex, int pageSize, 
            IEnumerable<Guid> authors = null, 
            IEnumerable<Guid> genres = null, 
            Guid? group = null,
            string title = null) : base()
        {
            var builder = Query.OrderBy(i => i.CreationDate)
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize)
                .Include(i => i.Authors)
                .Include(i => i.Genres)
                .Include(i => i.Group);

            if (!string.IsNullOrEmpty(title))
            {
                builder.Where(i => i.Title.Contains(title));
            }

            if (group.HasValue)
            {
                builder.Where(i => i.Group.Id == group.Value);
            }

            if (authors != null && authors.Any())
            {
                builder.Where(i => i.Authors.Any(i => authors.Contains(i.Id)));
            }

            if (genres != null && genres.Any())
            {
                builder.Where(i => i.Genres.Any(i => genres.Contains(i.Id)));
            }
        }
    }
}
