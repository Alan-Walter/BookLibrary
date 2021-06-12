namespace BookLibrary.Data.Models
{
    public class FileModel : BaseModel
    {
        public string TemporaryFilePath { get; set; }

        public string FileName { get; set; }

        public string FileType { get; set; }
    }
}
