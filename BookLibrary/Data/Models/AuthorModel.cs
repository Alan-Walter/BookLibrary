using System.ComponentModel.DataAnnotations;

namespace BookLibrary.Data.Models
{
    public class AuthorModel
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }
    }
}
