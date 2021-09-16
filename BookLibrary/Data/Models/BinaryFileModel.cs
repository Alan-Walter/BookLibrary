namespace BookLibrary.Data.Models
{
    public class BinaryFileModel : BaseModel
    {
        public string FileName { get; set; }

        public string FileType { get; set; }

        public string FilePath { get; set; }
    }
}
