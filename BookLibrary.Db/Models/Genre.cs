using System;
using System.Collections;
using System.Collections.Generic;

namespace BookLibrary.Db.Models
{
    public class Genre : IEntity
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public ICollection<Book> Books { get; set; }
    }
}
