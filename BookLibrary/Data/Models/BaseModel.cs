using System;
using System.Collections.Generic;

namespace BookLibrary.Data.Models
{
    public class BaseModel : IEquatable<BaseModel>
    {
        public Guid Id { get; set; }

        public override bool Equals(object obj)
        {
            return Equals(obj as BaseModel);
        }

        public bool Equals(BaseModel other)
        {
            return other != null &&
                   Id.Equals(other.Id);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }

        public static bool operator ==(BaseModel left, BaseModel right)
        {
            return EqualityComparer<BaseModel>.Default.Equals(left, right);
        }

        public static bool operator !=(BaseModel left, BaseModel right)
        {
            return !(left == right);
        }
    }
}
