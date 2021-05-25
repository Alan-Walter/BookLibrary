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
        [CustomValidation(typeof(BookModel), nameof(ValidateAuthors))]
        public ICollection<AuthorModel> Authors { get; set; } = new List<AuthorModel>();

        [Required]
        [CustomValidation(typeof(BookModel), nameof(ValidateFiles))]
        public ICollection<FileModel> Files { get; set; } = new List<FileModel>();


        public static ValidationResult ValidateAuthors(ICollection<AuthorModel> authors, ValidationContext vc)
        {
            return authors.Count > 0
                ? ValidationResult.Success
                : new ValidationResult("Authors cannot be empty", new[] { vc.MemberName });
        }

        public static ValidationResult ValidateFiles(ICollection<FileModel> files, ValidationContext vc)
        {
            return files.Count > 0
                ? ValidationResult.Success
                : new ValidationResult("Files cannot be empty", new[] { vc.MemberName });
        }
    }
}
