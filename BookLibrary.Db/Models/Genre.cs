using System;

namespace BookLibrary.Db.Models
{
    public class Genre : IEntity
    {
        public Guid Id { get; set; }

        public string Title { get; set; }
    }
}
