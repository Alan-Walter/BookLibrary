using BookLibrary.Db.Models;

using System.ComponentModel.DataAnnotations;

namespace BookLibrary.Data.Models
{
    public class AuthorModel : BaseModel<Author>
    {
        public AuthorModel(Author entity) : base(entity)
        {
            FirstName = entity.FirstName;
            MiddleName = entity.MiddleName;
            LastName = entity.LastName;
        }

        public AuthorModel()
        {

        }

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
