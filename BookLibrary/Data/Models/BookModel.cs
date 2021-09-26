using BookLibrary.Db.Models;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BookLibrary.Data.Models
{
    public class BookModel : EntityModel<Book>
    {
        [Required]
        public string Title { get; set; }

        public string Description { get; set; }

        [DataType(DataType.ImageUrl)]
        public string ImageUrl { get; set; }

        [Required]
        public IEnumerable<AuthorModel> Authors { get; set; }

        [Required]
        public IEnumerable<GenreModel> Genres { get; set; }

        [Required]
        public BookGroupModel Group { get; set; }

        public IEnumerable<BinaryFileModel> Files { get; set; }

        public DateTime CreationDate { get; set; }
    }
}
