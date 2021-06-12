using System.ComponentModel.DataAnnotations;

namespace BookLibrary.Data.Models
{
    public class AuthorModel : BaseModel
    {
        [Required]
        [MaxLength(255)]
        public string FirstName { get; set; }

        [MaxLength(255)]
        public string MiddleName { get; set; }

        [Required]
        [MaxLength(255)]
        public string LastName { get; set; }

        public override string ToString()
        {
            return !string.IsNullOrEmpty(MiddleName) ? $"{FirstName} {MiddleName} {LastName}" : $"{FirstName} {LastName}";
        }
    }
}
