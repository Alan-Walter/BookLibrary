using System.Collections.Generic;

namespace BookLibrary.Db.Models
{
    public class Book : Entity
    {
        public string Title { get; set; }

        public string ImageUrl { get; set; }

        public ICollection<Author> Authors { get; set; }
    }
}