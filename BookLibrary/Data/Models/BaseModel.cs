using BookLibrary.Db.Models;

using System;

namespace BookLibrary.Data.Models
{
    public class BaseModel<T> where T: IEntity
    {
        public Guid Id { get; }

        public T Entity { get; }

        public BaseModel(T entity)
        {
            Id = entity.Id;
            Entity = entity;
        }

        public BaseModel()
        {

        }
    }
}
