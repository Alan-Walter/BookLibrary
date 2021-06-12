using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BookLibrary.Data.Models
{
    public class BookModel : BaseModel
    {
        [Required]
        [MaxLength(255)]
        public string Title { get; set; }

        [MaxLength(255)]
        [DataType(DataType.ImageUrl)]
        public string ImageUrl { get; set; }

        [MaxLength(512)]
        public string Description { get; set; }

        [CustomValidation(typeof(BookModel), nameof(ValidateAuthors))]
        public ICollection<AuthorModel> Authors { get; set; }

        [CustomValidation(typeof(BookModel), nameof(ValidateFiles))]
        public ICollection<FileModel> Files { get; set; }

        public bool IsGroup { get; set; }

        public BookModel Parent { get; set; }

        public static ValidationResult ValidateAuthors(ICollection<AuthorModel> authors, ValidationContext vc)
        {
            return authors.Count > 0 || vc.ObjectInstance is BookModel model && model.Parent != null
                ? ValidationResult.Success
                : new ValidationResult("Authors cannot be empty", new[] { vc.MemberName });
        }

        public static ValidationResult ValidateFiles(ICollection<FileModel> files, ValidationContext vc)
        {
            return files.Count > 0 || vc.ObjectInstance is BookModel model && model.IsGroup
                ? ValidationResult.Success
                : new ValidationResult("Files cannot be empty", new[] { vc.MemberName });
        }
    }
}
