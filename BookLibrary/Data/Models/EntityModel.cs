using BookLibrary.Db.Models;

using System;
using System.Collections.Generic;

namespace BookLibrary.Data.Models
{
    public class EntityModel<T> : IEquatable<EntityModel<T>> where T : IEntity
    {
        public Guid Id { get; set; }

        public override bool Equals(object obj)
        {
            return Equals(obj as EntityModel<T>);
        }

        public bool Equals(EntityModel<T> other)
        {
            return other != null &&
                   Id.Equals(other.Id);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }

        public static bool operator ==(EntityModel<T> left, EntityModel<T> right)
        {
            return EqualityComparer<EntityModel<T>>.Default.Equals(left, right);
        }

        public static bool operator !=(EntityModel<T> left, EntityModel<T> right)
        {
            return !(left == right);
        }
    }
}
