using BookLibrary.Db.Models;

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

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

        [MaxLength(512)]
        public string Description { get; set; }

        [CustomValidation(typeof(BookModel), nameof(ValidateAuthors))]
        public ICollection<AuthorModel> Authors { get; set; } = new List<AuthorModel>();

        [CustomValidation(typeof(BookModel), nameof(ValidateFiles))]
        public ICollection<FileModel> Files { get; set; } = new List<FileModel>();

        public bool IsGroup { get; set; }

        public BookModel Parent { get; set; }

        public BookModel() : base()
        {

        }

        public BookModel(Book book) : base(book)
        {
            Title = book.Title;
            Description = book.Description;
            ImageUrl = book.ImageUrl;
            Authors = book.Authors.Select(i => new AuthorModel(i)).ToList();
            IsGroup = book.IsGroup;
            Files = book.Files.Select(i => new FileModel(i)).ToList();
            Parent = new BookModel(book.Parent);
        }


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
