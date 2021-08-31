using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary.Db.Models
{
    public class BookGroup : IEntity
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public BookGroup Parent { get; set; }

        public ICollection<BookGroup> Childs { get; set; }

        public ICollection<Book> Books { get; set; }
    }
}
