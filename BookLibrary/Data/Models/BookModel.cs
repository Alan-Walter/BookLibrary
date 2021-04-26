using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BookLibrary.Data.Models
{
    public class BookModel
    {
        [Required]
        public string Title { get; set; }

        public string ImageUrl { get; set; }

        [Required]
        public ICollection<AuthorModel> Authors { get; set; } 
    }
}
