using Ardalis.Specification;

using BookLibrary.Db.Models;

namespace BookLibrary.Db.Specifications
{
    public class BookEmptySpecification : Specification<Book>
    {
        public BookEmptySpecification() : base()
        {
        }
    }
}
