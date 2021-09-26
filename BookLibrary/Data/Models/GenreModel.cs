using BookLibrary.Db.Models;

namespace BookLibrary.Data.Models
{
    public class GenreModel : EntityModel<Genre>
    {
        public string Title { get; set; }

        public override string ToString()
        {
            return Title;
        }
    }
}
