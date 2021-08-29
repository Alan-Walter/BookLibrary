using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookLibrary.Data.Models
{
    public class BookGroupModel : BaseModel
    {
        public string Uid => Id.ToString();

        [Required]
        [MaxLength(255)]
        [DisplayName("Title")]
        public string Title { get; set; }

        [DisplayName("Parent group")]
        public BookGroupModel Parent { get; set; }

        public List<BookGroupModel> Childs { get; set; }

    }
}
