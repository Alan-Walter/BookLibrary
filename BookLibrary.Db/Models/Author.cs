using System.Collections.Generic;

namespace BookLibrary.Db.Models
{
    public class Author : Entity
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public ICollection<Book> Books { get; set; }
    }
}