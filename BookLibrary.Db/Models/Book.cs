using System.Collections.Generic;

namespace BookLibrary.Db.Models
{
    public class Book : Entity
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }

        public bool IsGroup { get; set; }

        public ICollection<Author> Authors { get; set; }

        public ICollection<BinaryFile> Files { get; set; }


        public Book Parent { get; set; }

        public ICollection<Book> Childs { get; set; }
    }
}