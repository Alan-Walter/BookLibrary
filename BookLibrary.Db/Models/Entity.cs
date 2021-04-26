using System;

namespace BookLibrary.Db.Models
{
    public abstract class Entity : IEntity
    {
        public virtual Guid Id { get; set; }
    }
}