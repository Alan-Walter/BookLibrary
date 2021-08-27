using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookLibrary.Data.Models
{
    public class BookGroupModel : BaseModel
    {
        [Required]
        [MaxLength(255)]
        public string Title { get; set; }

        public BookGroupModel Parent { get; set; }

        public List<BookGroupModel> Childs { get; set; }

    }
}
