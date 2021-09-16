using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BookLibrary.Data.Models
{
    public class BookModel : BaseModel
    {
        [Required]
        public string Title { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }

        public ICollection<AuthorModel> Authors { get; set; }

        public ICollection<GenreModel> Genres { get; set; }

        public BookGroupModel Group { get; set; }

        public ICollection<BinaryFileModel> Files { get; set; }

        public DateTime CreationDate { get; set; }
    }
}
