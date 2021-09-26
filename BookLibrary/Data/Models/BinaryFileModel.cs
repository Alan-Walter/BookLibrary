using BookLibrary.Db.Models;

namespace BookLibrary.Data.Models
{
    public class BinaryFileModel : EntityModel<BinaryFile>
    {
        public string FileName { get; set; }

        public string FileType { get; set; }
    }
}
