using System.Collections.Generic;

namespace BookLibrary.Data.Models
{
    public class BookSearchModel
    {
        public string Title { get; set; }

        public IEnumerable<AuthorModel> Authors { get; set; }

        public IEnumerable<GenreModel> Genres { get; set; }

        public BookGroupModel Group { get; set; }
    }
}
