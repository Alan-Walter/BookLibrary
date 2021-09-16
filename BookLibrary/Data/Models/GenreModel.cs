namespace BookLibrary.Data.Models
{
    public class GenreModel : BaseModel
    {
        public string Title { get; set; }

        public override string ToString()
        {
            return Title;
        }
    }
}
