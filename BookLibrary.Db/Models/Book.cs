
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookLibrary.Db.Models
{
    public class Book : IEntity
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public ICollection<Author> Authors { get; set; }
    }
}
