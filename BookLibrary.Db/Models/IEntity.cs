using System;

namespace BookLibrary.Db.Models
{
    public interface IEntity
    {
        Guid Id { get; set; }
    }
}