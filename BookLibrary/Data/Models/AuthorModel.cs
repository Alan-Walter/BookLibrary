using System.ComponentModel.DataAnnotations;

namespace BookLibrary.Data.Models
{
    public class AuthorModel : BaseModel
    {
        [Required]
        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        [Required]
        public string LastName { get; set; }

        public string FullName => this.ToString();

        public override string ToString()
        {
            return string.Join(" ", FirstName, MiddleName, LastName);
        }
    }
}
