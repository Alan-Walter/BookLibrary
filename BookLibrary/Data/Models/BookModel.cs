using BookLibrary.Db.Models;

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BookLibrary.Data.Models
{
    public class BookModel : BaseModel<Book>
    {
        [Required]
        [MaxLength(255)]
        public string Title { get; set; }

        [MaxLength(255)]
        [DataType(DataType.ImageUrl)]
        public string ImageUrl { get; set; }

        [Required]
        public ICollection<AuthorModel> Authors { get; set; } = new List<AuthorModel>();
    }
}
