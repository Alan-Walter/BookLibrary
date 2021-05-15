using BookLibrary.Db.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookLibrary.Data.Models
{
    public class BaseModel<T> where T: IEntity
    {
        public Guid Id { get; set; }

        public BaseModel(T entity)
        {
            Id = entity.Id;
        }

        public BaseModel()
        {

        }
    }
}
